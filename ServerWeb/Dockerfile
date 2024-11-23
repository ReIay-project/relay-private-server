FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ServerWeb/ServerWeb.csproj", "ServerWeb/"]
COPY ["DataBaseService/DataBaseService.csproj", "DataBaseService/"]
COPY ["ServerCore/ServerCore.csproj", "ServerCore/"]
COPY ["ServerApp/ServerApp.csproj", "ServerApp/"]
COPY ["ServerWebCore/ServerWebCore.csproj", "ServerWebCore/"]
RUN dotnet restore "ServerWeb/ServerWeb.csproj"
COPY . .
WORKDIR "/src/ServerWeb"
RUN dotnet build "ServerWeb.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ServerWeb.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ServerWeb.dll"]
