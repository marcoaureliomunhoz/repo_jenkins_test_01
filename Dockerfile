FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build

WORKDIR /app
COPY *.sln .
COPY api/*.csproj ./api/
RUN dotnet restore

COPY api/. ./api/
WORKDIR /app/api
RUN dotnet publish biblio_api.csproj -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS runtime
WORKDIR /app
COPY --from=build /app/api/out ./
ENTRYPOINT ["dotnet", "biblio_api.dll"]