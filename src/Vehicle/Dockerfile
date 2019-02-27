FROM microsoft/dotnet:2.2-aspnetcore-runtime-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk-stretch AS build
WORKDIR /src
COPY ["Vehicle/Vehicle.csproj", "Vehicle/"]
COPY ["Vehicle.ReadStore/Vehicle.ReadStore.csproj", "Vehicle.ReadStore/"]
COPY ["EventStore/EventStore.csproj", "EventStore/"]
COPY ["VehicleTracker/VehicleTracker.csproj", "VehicleTracker/"]
RUN dotnet restore "Vehicle/Vehicle.csproj"
COPY . .
WORKDIR "/src/Vehicle"
RUN dotnet build "Vehicle.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Vehicle.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Vehicle.dll"]