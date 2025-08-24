FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["DivisoresEPrimos.WebApi/DivisoresEPrimos.WebApi.csproj", "DivisoresEPrimos.WebApi/"]
RUN dotnet restore "DivisoresEPrimos.WebApi/DivisoresEPrimos.WebApi.csproj"
COPY . .
WORKDIR /src/DivisoresEPrimos.WebApi
RUN dotnet build "DivisoresEPrimos.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DivisoresEPrimos.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DivisoresEPrimos.WebApi.dll"]