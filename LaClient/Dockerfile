FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["LaClient/LaClient.csproj", "LaClient/"]
RUN dotnet restore "LaClient/LaClient.csproj"
COPY . .
WORKDIR "/src/LaClient"
RUN dotnet build "LaClient.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LaClient.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LaClient.dll"]
