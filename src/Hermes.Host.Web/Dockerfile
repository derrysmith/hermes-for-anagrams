FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Hermes.Host.Web/Hermes.Host.Web.csproj", "Hermes.Host.Web/"]
RUN dotnet restore "src/Hermes.Host.Web/Hermes.Host.Web.csproj"
COPY . .
WORKDIR "/src/Hermes.Host.Web"
RUN dotnet build "Hermes.Host.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Hermes.Host.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Hermes.Host.Web.dll"]
