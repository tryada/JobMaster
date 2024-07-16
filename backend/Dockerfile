FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["backend/src/JobMaster.Api/JobMaster.Api.csproj", "/JobMaster.Api/"]
COPY ["backend/src/JobMaster.Application/JobMaster.Application.csproj", "/JobMaster.Application/"]
COPY ["backend/src/JobMaster.Contracts/JobMaster.Contracts.csproj", "/JobMaster.Contracts/"]
COPY ["backend/src/JobMaster.Domain/JobMaster.Domain.csproj", "/JobMaster.Domain/"]
COPY ["backend/src/JobMaster.Infrastructure/JobMaster.Infrastructure.csproj", "/JobMaster.Infrastructure/"]
RUN dotnet restore "/JobMaster.Api/JobMaster.Api.csproj"
COPY /backend/src .
WORKDIR "/src/JobMaster.Api"
RUN dotnet build "./JobMaster.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./JobMaster.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JobMaster.Api.dll"]