FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Hermes.Api/Hermes.Api.csproj", "Hermes.Api/"]
RUN dotnet restore "src/Hermes.Api/Hermes.Api.csproj"
COPY . .
WORKDIR "/src/Hermes.Api"
RUN dotnet build "Hermes.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Hermes.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Hermes.Api.dll"]
