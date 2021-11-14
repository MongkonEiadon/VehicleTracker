FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MicroServices/Vehicles/Vehicles.Service/Vehicles.Service.csproj", "MicroServices/Vehicles/Vehicles.Service/"]
COPY ["Infrastructures/EventStore.Middleware/EventStore.Middleware.csproj", "Infrastructures/EventStore.Middleware/"]
COPY ["Infrastructures/Infrastructure/Infrastructure.csproj", "Infrastructures/Infrastructure/"]
COPY ["MicroServices/Vehicles/Vehicles.ReadStore/Vehicles.ReadStore.csproj", "MicroServices/Vehicles/Vehicles.ReadStore/"]
COPY ["Domain/Domain.csproj", "Domain/"]
RUN dotnet restore "MicroServices/Vehicles/Vehicles.Service/Vehicles.Service.csproj"
COPY . .
WORKDIR "/src/MicroServices/Vehicles/Vehicles.Service"
RUN dotnet build "Vehicles.Service.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Vehicles.Service.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Vehicles.Service.dll"]