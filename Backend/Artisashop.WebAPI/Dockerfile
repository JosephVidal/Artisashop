FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Backend/Artisashop.WebAPI/Artisashop.WebAPI.csproj", "Artisashop.WebAPI/"]
RUN dotnet restore "Backend/Artisashop.WebAPI/Artisashop.WebAPI.csproj"
COPY . .
WORKDIR "/src/Artisashop.WebAPI"
RUN dotnet build "Artisashop.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Artisashop.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Artisashop.WebAPI.dll"]
