FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["LaAPI/LaAPI.csproj", "LaAPI/"]
RUN dotnet restore "LaAPI/LaAPI.csproj"
COPY . .
WORKDIR "/src/LaAPI"
RUN dotnet build "LaAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LaAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LaAPI.dll"]
