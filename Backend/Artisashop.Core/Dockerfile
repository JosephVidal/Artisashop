FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Backend/Artisashop.Core/Artisashop.Core.csproj", "Artisashop.Core/"]
RUN dotnet restore "Backend/Artisashop.Core/Artisashop.Core.csproj"
COPY . .
WORKDIR "/src/Artisashop.Core"
RUN dotnet build "Artisashop.Core.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Artisashop.Core.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Artisashop.Core.dll"]
