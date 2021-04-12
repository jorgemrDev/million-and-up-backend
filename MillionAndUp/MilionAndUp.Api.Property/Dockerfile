#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["MilionAndUp.Api.Property/MilionAndUp.Api.Property.csproj", "MilionAndUp.Api.Property/"]
COPY ["MillionAndUp.Repository/MillionAndUp.Repository.csproj", "MillionAndUp.Repository/"]
COPY ["MillionAndUp.Models/MillionAndUp.Models.csproj", "MillionAndUp.Models/"]
RUN dotnet restore "MilionAndUp.Api.Property/MilionAndUp.Api.Property.csproj"
COPY . .
WORKDIR "/src/MilionAndUp.Api.Property"
RUN dotnet build "MilionAndUp.Api.Property.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MilionAndUp.Api.Property.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MilionAndUp.Api.Property.dll"]
