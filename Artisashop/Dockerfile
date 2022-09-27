#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Artichaut/Artichaut.csproj", "Artichaut/"]
COPY ["CmaApi/src/CmaApi/CmaApi.csproj", "CmaApi/src/CmaApi/"]
COPY ["RechercheEntreprisesApi/src/RechercheEntreprisesApi/RechercheEntreprisesApi.csproj", "RechercheEntreprisesApi/src/RechercheEntreprisesApi/"]
RUN dotnet restore "Artichaut/Artichaut.csproj"
COPY . .
WORKDIR "/src/Artichaut"
RUN dotnet build "Artichaut.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Artichaut.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Artichaut.dll"]