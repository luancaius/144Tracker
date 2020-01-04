FROM microsoft/aspnetcore-build:3.0 AS build-env
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore -s https://api.nuget.org/v3/index.json

COPY . ./
RUN dotnet publish -c Release -o out

FROM microsoft/aspnetcore:3.0
COPY --from=build-env /app/out .

EXPOSE 5000/tcp
ENV ASPNETCORE_URLS http://*:5000

ENTRYPOINT ["dotnet", "WebAPI.dll"]