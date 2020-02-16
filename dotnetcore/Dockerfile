FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY src/WebAPI/*.csproj ./src/WebAPI/
COPY src/GrabData/*.csproj ./src/GrabData/
COPY src/Services/*.csproj ./src/Services/
COPY src/Interfaces/*.csproj ./src/Interfaces/
COPY src/Repository/*.csproj ./src/Repository/
COPY src/DomainModel/*.csproj ./src/DomainModel/
COPY src/Provider.NextBus/*.csproj ./src/Provider.NextBus/
RUN dotnet restore 

# copy everything else and build app
COPY src/WebAPI/ src/WebAPI/
COPY src/GrabData/ src/GrabData/
COPY src/Services/ src/Services/
COPY src/Interfaces/ src/Interfaces/
COPY src/Repository/ src/Repository/
COPY src/DomainModel/ src/DomainModel/
COPY src/Provider.NextBus/ src/Provider.NextBus/

WORKDIR /source/src/WebAPI
RUN dotnet build -c release 

FROM build AS publish
RUN dotnet publish -c release --no-build -o /app


# final stage/image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WebAPI.dll"]