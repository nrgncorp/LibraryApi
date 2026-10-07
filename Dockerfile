# ---------- 1. AŞAMA: Derleme ----------
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY Core/Kutuphane.Domain/Kutuphane.Domain.csproj Core/Kutuphane.Domain/
COPY Core/Kutuphane.Application/Kutuphane.Application.csproj Core/Kutuphane.Application/
COPY Infrastructure/Kutuphane.Infrastructure/Kutuphane.Infrastructure.csproj Infrastructure/Kutuphane.Infrastructure/
COPY Infrastructure/Kutuphane.Persistence/Kutuphane.Persistence.csproj Infrastructure/Kutuphane.Persistence/
COPY Presentation/Kutuphane.Api/Kutuphane.Api.csproj Presentation/Kutuphane.Api/
RUN dotnet restore Presentation/Kutuphane.Api/Kutuphane.Api.csproj

COPY . .
RUN dotnet publish Presentation/Kutuphane.Api/Kutuphane.Api.csproj -c Release -o /app

# ---------- 2. AŞAMA: Çalıştırma ----------
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "Kutuphane.Api.dll"]