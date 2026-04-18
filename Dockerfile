# Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY . .

WORKDIR /src/src/EcoPulse.Api
RUN dotnet restore EcoPulse.Api.csproj
RUN dotnet publish EcoPulse.Api.csproj -c Release -o /app/out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "EcoPulse.Api.dll"]