#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["FhirNexusShaun.IntegrationTests/FhirNexusShaun.IntegrationTests.csproj", "FhirNexusShaun.IntegrationTests/"]
COPY ["FhirNexusShaun/FhirNexusShaun.csproj", "FhirNexusShaun/"]
COPY ["FhirNexusShaun.Model/FhirNexusShaun.Model.csproj", "FhirNexusShaun.Model/"]
RUN dotnet restore "./FhirNexusShaun.IntegrationTests/FhirNexusShaun.IntegrationTests.csproj"
COPY . .
WORKDIR "/src/FhirNexusShaun.IntegrationTests"
RUN dotnet build "./FhirNexusShaun.IntegrationTests.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./FhirNexusShaun.IntegrationTests.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FhirNexusShaun.IntegrationTests.dll"]