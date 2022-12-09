#### image layer base
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /target

# expose 8080 for google cloud run
EXPOSE 8080
ENV ASPNETCORE_URLS=http://*:8080


#### image layer for restore, build, and testing
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS compile
WORKDIR /source

# copy files needed for restore
COPY ./*.sln ./
COPY ./src/*/*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p src/${file%.*}/ && mv $file src/${file%.*}/; done
#COPY ./test/*/*.csproj ./
#RUN for file in $(ls *.csproj); do mkdir -p test/${file%.*}/ && mv $file test/${file%.*}/; done

#COPY ./src/Hermes.Host.Web/Hermes.Host.Web.csproj ./Hermes.Host.Api/

# restore dependencies
RUN dotnet restore hermes.sln

# copy remaining files to container
COPY . .

# build projects
RUN dotnet build hermes.sln --configuration Release --nologo --no-restore
RUN dotnet test hermes.sln --configuration Release --no-build --nologo --verbosity normal

#### image layer for publishing executables
FROM compile AS publish

# publish projects
RUN dotnet publish ./src/Hermes.Host.Web/Hermes.Host.Web.csproj --configuration Release --no-build --output /target/publish


#### image layer containing artifacts
FROM runtime AS release
WORKDIR /target

# copy artifacts from publish layer to final layer
COPY --from=publish /target/publish .

# executable to run
ENTRYPOINT [ "dotnet", "Hermes.Host.Web.dll" ]