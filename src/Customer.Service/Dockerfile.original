FROM microsoft/dotnet:2.2-aspnetcore-runtime-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk-stretch AS build
WORKDIR /src
COPY ["Vehicle.Service/Vehicle.Service.csproj", "Vehicle.Service/"]
COPY ["VehicleTracker/VehicleTracker.csproj", "VehicleTracker/"]
COPY ["EventStore/EventStore.csproj", "EventStore/"]
COPY ["Vehicle.ReadStore/Vehicle.ReadStore.csproj", "Vehicle.ReadStore/"]
RUN dotnet restore "Vehicle.Service/Vehicle.Service.csproj"
COPY . .
WORKDIR "/src/Vehicle.Service"
RUN dotnet build "Vehicle.Service.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Vehicle.Service.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Vehicle.Service.dll"]