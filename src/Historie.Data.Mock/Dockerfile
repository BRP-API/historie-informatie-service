#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Historie.Data.Mock/Historie.Data.Mock.csproj", "Historie.Data.Mock/"]
RUN dotnet restore "./Historie.Data.Mock/Historie.Data.Mock.csproj"
COPY . .
COPY config/Historie.Data.Mock/test-data.json Historie.Data.Mock/Data/test-data.json
RUN rm Historie.Informatie.Service/appsettings.json
RUN rm Historie.Informatie.Service/appsettings.Development.json
WORKDIR "/src/Historie.Data.Mock"
RUN dotnet build "./Historie.Data.Mock.csproj" -c "$BUILD_CONFIGURATION" -o /app/build

FROM build AS publish
RUN dotnet publish "./Historie.Data.Mock.csproj" -c "$BUILD_CONFIGURATION" -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# See https://github.com/Contrast-Security-OSS/agent-operator/blob/master/docs/public/08-tips.md
ENV DOTNET_HOSTBUILDER__RELOADCONFIGONCHANGE=false

ENTRYPOINT ["dotnet", "Historie.Data.Mock.dll"]