FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Install Node.js
RUN curl -fsSL https://deb.nodesource.com/setup_16.x | bash - \
    && apt-get install -y \
        nodejs \
    && rm -rf /var/lib/apt/lists/*
RUN ["npm", "install", "--global", "yarn"]
RUN ["corepack", "enable"]
RUN ["yarn", "set", "version", "stable"]

WORKDIR /src
COPY ["Artisashop/Artisashop.csproj", "Artisashop/"]
RUN dotnet restore "Artisashop/Artisashop.csproj"
COPY . .
WORKDIR "/src/Artisashop"
RUN dotnet build "Artisashop.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Artisashop.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Artisashop.dll"]
