FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["src/WebAPI/WebAPI.csproj", "src/WebAPI/"]
COPY ["src/Interfaces/Interfaces.csproj", "src/Interfaces/"]
COPY ["src/DomainModel/DomainModel.csproj", "src/DomainModel/"]
COPY ["src/Services/Services.csproj", "src/Services/"]
COPY ["src/Provider.NextBus/Provider.NextBus.csproj", "src/Provider.NextBus/"]
COPY ["src/Repository/Repository.csproj", "src/Repository/"]
RUN dotnet restore "src/WebAPI/WebAPI.csproj"
COPY . .
WORKDIR "/src/src/WebAPI"
RUN dotnet build "WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebAPI.dll"]