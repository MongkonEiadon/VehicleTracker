FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Gateway/ServicesGateway/ServicesGateway.csproj", "Gateway/ServicesGateway/"]
RUN dotnet restore "Gateway/ServicesGateway/ServicesGateway.csproj"
COPY . .
WORKDIR "/src/Gateway/ServicesGateway"
RUN dotnet build "ServicesGateway.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ServicesGateway.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ServicesGateway.dll"]