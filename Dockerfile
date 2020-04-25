FROM microsoft/dotnet:2.2-sdk AS build

WORKDIR /app
COPY *.sln .
COPY api/*.csproj ./api/
COPY test/*.csproj ./test/
RUN dotnet restore

COPY api/. ./api/
COPY test/. ./test/
WORKDIR /app/api
RUN dotnet publish biblio_api.csproj -o out

FROM build AS test
WORKDIR /app
CMD ["dotnet", "test", "--logger:trx"]

#FROM microsoft/dotnet:2.2-aspnetcore-runtime AS runtime
FROM build AS runtime
WORKDIR /app
COPY --from=build /app/api/out ./
ENTRYPOINT ["dotnet", "biblio_api.dll"]