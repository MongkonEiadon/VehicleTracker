FROM microsoft/dotnet:2.2-aspnetcore-runtime-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk-stretch AS build
WORKDIR /src
COPY ["Customer.Service/Customer.Service.csproj", "Customer.Service/"]
COPY ["VehicleTracker.Infrastructure/VehicleTracker.Infrastructure.csproj", "VehicleTracker.Infrastructure/"]
COPY ["Customer.ReadStore/Customer.ReadStore.csproj", "Customer.ReadStore/"]
COPY ["VehicleTracker/VehicleTracker.csproj", "VehicleTracker/"]
COPY ["EventStore/EventStore.csproj", "EventStore/"]
RUN dotnet restore "Customer.Service/Customer.Service.csproj"
COPY . .
WORKDIR "/src/Customer.Service"
RUN dotnet build "Customer.Service.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Customer.Service.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Customer.Service.dll"]