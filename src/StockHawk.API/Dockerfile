FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/StockHawk.API/StockHawk.API.csproj", "src/StockHawk.API/"]
COPY ["src/StockHawk.DataAccess/StockHawk.DataAccess.csproj", "src/StockHawk.DataAccess/"]
COPY ["src/StockHawk.Model/StockHawk.Model.csproj", "src/StockHawk.Model/"]
RUN dotnet restore "src/StockHawk.API/StockHawk.API.csproj"
COPY . .
WORKDIR "/src/src/StockHawk.API"
RUN dotnet build "StockHawk.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StockHawk.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StockHawk.API.dll", "--urls", "http://*:8080"]
