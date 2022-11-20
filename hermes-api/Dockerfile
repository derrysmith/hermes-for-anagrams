#### image layer base
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /target
# expose 8080 for google cloud run
EXPOSE 8080
ENV ASPNETCORE_URLS=htp://*:8080


#### image layer for restore, building, and testing
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS compile
WORKDIR /source

# only copy files needed for restore
COPY ./*.sln ./
COPY ./src/*/*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p src/${file%.*}/ && mv $file src/${file%.*}/; done
#COPY ./test/*/*.csproj ./
#RUN for file in $(ls *.csproj); do mkdir -p test/${file%.*}/ && mv $file test/${file%.*}/; done

# restore dependencies
RUN dotnet restore hermes-api.sln

# copy remaining files to container
COPY . .

# build and test libraries
RUN dotnet build hermes-api.sln --configuration Release --nologo --no-restore
RUN dotnet test hermes-api.sln --configuration Release --no-build --nologo --verbosity normal


#### image layer for publishing executables
FROM compile AS publish

# publish executables
RUN dotnet publish ./src/Hermes.Api/Hermes.Api.csproj --configuration Release --no-build --output /target/publish


#### image layer containing published artifacts
FROM runtime AS release
WORKDIR /target

# copy artifacts from publish layer to final layer
COPY --from=publish /target/publish .

# executable to run
ENTRYPOINT [ "dotnet", "Hermes.Api.dll" ]
