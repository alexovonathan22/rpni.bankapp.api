FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

# Ensure we listen on any IP Address 
ENV DOTNET_URLS=http://+:5000
RUN apt-get update && apt-get install -y curl

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY [".", "./"]
RUN dotnet restore "RpnInnovation.WebApi\RpnInnovation.WebApi.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "RpnInnovation.WebApi\RpnInnovation.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RpnInnovation.WebApi\RpnInnovation.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RpnInnovation.WebApi.dll"]
#RpnInnovation.WebApi\RpnInnovation.WebApi.dll
#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.