FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MicroServices/Trackers/Trackers.Service/Trackers.Service.csproj", "MicroServices/Trackers/Trackers.Service/"]
COPY ["Infrastructures/EventStore.Middleware/EventStore.Middleware.csproj", "Infrastructures/EventStore.Middleware/"]
COPY ["Infrastructures/Infrastructure/Infrastructure.csproj", "Infrastructures/Infrastructure/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["MicroServices/Trackers/Trackers.ReadStore/Trackers.ReadStore.csproj", "MicroServices/Trackers/Trackers.ReadStore/"]
RUN dotnet restore "MicroServices/Trackers/Trackers.Service/Trackers.Service.csproj"
COPY . .
WORKDIR "/src/MicroServices/Trackers/Trackers.Service"
RUN dotnet build "Trackers.Service.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Trackers.Service.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Trackers.Service.dll"]