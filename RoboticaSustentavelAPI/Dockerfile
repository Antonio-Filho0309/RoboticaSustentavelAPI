# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# Base image for runtime (used in final stage)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy and restore project
COPY ["RoboticaSustentavelAPI/RoboticaSustentavelAPI.csproj", "./"]
RUN dotnet restore "./RoboticaSustentavelAPI.csproj"

# Copy all files
COPY . .
WORKDIR "/src/."

RUN dotnet publish "./RoboticaSustentavelAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final image
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "RoboticaSustentavelAPI.dll"]
