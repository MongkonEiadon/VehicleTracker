FROM microsoft/dotnet:2.2-aspnetcore-runtime-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk-stretch AS build
WORKDIR /src
COPY ["Tracking.Service/Tracking.Service.csproj", "Tracking.Service/"]
COPY ["VehicleTracker.Infrastructure/VehicleTracker.Infrastructure.csproj", "VehicleTracker.Infrastructure/"]
COPY ["Tracking.ReadStore/Tracking.ReadStore.csproj", "Tracking.ReadStore/"]
COPY ["VehicleTracker/VehicleTracker.csproj", "VehicleTracker/"]
COPY ["EventStore/EventStore.csproj", "EventStore/"]
RUN dotnet restore "Tracking.Service/Tracking.Service.csproj"
COPY . .
WORKDIR "/src/Tracking.Service"
RUN dotnet build "Tracking.Service.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Tracking.Service.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Tracking.Service.dll"]