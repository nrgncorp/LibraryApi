# ---------- 1. AŞAMA: Derleme ----------
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY src/Kutuphane.Domain/Kutuphane.Domain.csproj src/Kutuphane.Domain/
COPY src/Kutuphane.Application/Kutuphane.Application.csproj src/Kutuphane.Application/
COPY src/Kutuphane.Infrastructure/Kutuphane.Infrastructure.csproj src/Kutuphane.Infrastructure/
COPY src/Kutuphane.Api/Kutuphane.Api.csproj src/Kutuphane.Api/
RUN dotnet restore src/Kutuphane.Api/Kutuphane.Api.csproj

COPY . .
RUN dotnet publish src/Kutuphane.Api/Kutuphane.Api.csproj -c Release -o /app

# ---------- 2. AŞAMA: Çalıştırma ----------
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "Kutuphane.Api.dll"]