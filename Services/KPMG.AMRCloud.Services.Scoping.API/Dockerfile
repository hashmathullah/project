#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Services/KPMG.AMRCloud.Services.Scoping.API/KPMG.AMRCloud.Services.Scoping.API.csproj", "Services/KPMG.AMRCloud.Services.Scoping.API/"]
COPY ["Services/Scoping/KPMG.AMRCloud.Services.Scoping.Infrastructure/KPMG.AMRCloud.Services.Scoping.Infrastructure.csproj", "Services/Scoping/KPMG.AMRCloud.Services.Scoping.Infrastructure/"]
COPY ["Services/Scoping/KPMG.AMRCloud.Services.Scoping.Domain/KPMG.AMRCloud.Services.Scoping.Domain.csproj", "Services/Scoping/KPMG.AMRCloud.Services.Scoping.Domain/"]
COPY ["Services/Scoping/KPMG.AMRCloud.Services.Scoping.Application/KPMG.AMRCloud.Services.Scoping.Application.csproj", "Services/Scoping/KPMG.AMRCloud.Services.Scoping.Application/"]
RUN dotnet restore "Services/KPMG.AMRCloud.Services.Scoping.API/KPMG.AMRCloud.Services.Scoping.API.csproj"
COPY . .
WORKDIR "/src/Services/KPMG.AMRCloud.Services.Scoping.API"
RUN dotnet build "KPMG.AMRCloud.Services.Scoping.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KPMG.AMRCloud.Services.Scoping.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KPMG.AMRCloud.Services.Scoping.API.dll"]