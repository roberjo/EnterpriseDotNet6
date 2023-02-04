#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EnterpriseDotNet6/EnterpriseDotNet6.csproj", "EnterpriseDotNet6/"]
RUN dotnet restore "EnterpriseDotNet6/EnterpriseDotNet6.csproj"
COPY . .
WORKDIR "/src/EnterpriseDotNet6"
RUN dotnet build "EnterpriseDotNet6.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EnterpriseDotNet6.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EnterpriseDotNet6.dll"]