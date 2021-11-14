FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Apps/EventStore.App/EventStore.App.csproj", "Apps/EventStore.App/"]
COPY ["Infrastructures/EventStore.Middleware/EventStore.Middleware.csproj", "Infrastructures/EventStore.Middleware/"]
COPY ["Infrastructures/Infrastructure/Infrastructure.csproj", "Infrastructures/Infrastructure/"]
RUN dotnet restore "Apps/EventStore.App/EventStore.App.csproj"
COPY . .
WORKDIR "/src/Apps/EventStore.App"
RUN dotnet build "EventStore.App.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "EventStore.App.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "EventStore.App.dll"]