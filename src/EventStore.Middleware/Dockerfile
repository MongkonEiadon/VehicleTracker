FROM microsoft/dotnet:2.2-runtime-stretch-slim AS base
WORKDIR /app

FROM microsoft/dotnet:2.2-sdk-stretch AS build
WORKDIR /src
COPY ["EventStore.Middleware/EventStore.Middleware.csproj", "EventStore.Middleware/"]
COPY ["VehicleTracker/VehicleTracker.csproj", "VehicleTracker/"]
COPY ["EventStore/EventStore.csproj", "EventStore/"]
RUN dotnet restore "EventStore.Middleware/EventStore.Middleware.csproj"
COPY . .
WORKDIR "/src/EventStore.Middleware"
RUN dotnet build "EventStore.Middleware.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "EventStore.Middleware.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "EventStore.Middleware.dll"]
