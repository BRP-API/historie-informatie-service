#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Historie.Informatie.Service/Historie.Informatie.Service.csproj", "Historie.Informatie.Service/"]
RUN dotnet restore "./Historie.Informatie.Service/Historie.Informatie.Service.csproj"
COPY . .
WORKDIR "/src/Historie.Informatie.Service"
RUN dotnet build "./Historie.Informatie.Service.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Historie.Informatie.Service.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Historie.Informatie.Service.dll"]