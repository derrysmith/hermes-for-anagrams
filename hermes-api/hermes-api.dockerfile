FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /target
EXPOSE 8080
ENV ASPNETCORE_URLS=http://*:8080

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS compile
WORKDIR /source
ARG PACKAGE_FEED_USERNAME
ARG PACKAGE_FEED_PASSWORD

# copy .sln, .csproj, and nuget.config
COPY ./*.sln ./nuget.config ./
COPY ./src/*/*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p src/${file%.*}/ && mv $file src/${file%.*}/; done
COPY ./test/*/*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p test/${file%.*}/ && mv $file test/${file%.*}/; done

# restore dependencies
RUN dotnet nuget update source github --configfile nuget.config --username $PACKAGE_FEED_USERNAME --password $PACKAGE_FEED_PASSWORD --store-password-in-clear-text
RUN dotnet restore hermes-api.sln --configfile nuget.config

# copy remaining files to container
COPY . .

# compile and test libraries
RUN dotnet build hermes-api.sln --configuration Release --no-restore --nologo
RUN dotnet test hermes-api.sln --configuration Release --no-build --nologo --verbosity normal

FROM compile AS publish
## publish executables
RUN dotnet publish ./src/Hermes.Api/Hermes.Api.csproj --configuration Release --no-build --output /target/publish

FROM runtime AS release
WORKDIR /target

## copy artifacts from publish layer to final layer
COPY --from=publish /target/publish .

ENTRYPOINT [ "dotnet", "Hermes.Api.dll" ]