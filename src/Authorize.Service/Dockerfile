FROM microsoft/dotnet:2.2-aspnetcore-runtime-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk-stretch AS build
WORKDIR /src
COPY ["Authorize.Service/Autorize.Service.csproj", "Authorize.Service/"]
COPY ["VehicleTracker.Infrastructure.Identity/VehicleTracker.Infrastructure.Identity.csproj", "VehicleTracker.Infrastructure.Identity/"]
COPY ["VehicleTracker.Infrastructure/VehicleTracker.Infrastructure.csproj", "VehicleTracker.Infrastructure/"]
COPY ["VehicleTracker/VehicleTracker.csproj", "VehicleTracker/"]
RUN dotnet restore "Authorize.Service/Autorize.Service.csproj"
COPY . .
WORKDIR "/src/Authorize.Service"
RUN dotnet build "Autorize.Service.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Autorize.Service.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Autorize.Service.dll"]