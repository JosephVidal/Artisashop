# Artisashop

Source for the Artisashop EIP (Epitech Innovative Project).

## Architecture

Ce projet est un monorepo composé d'un backend en .NET 6 et d'un frontend en React.

Les deux applications sont séparées dans leurs dossiers respectifs `Backend/` et `Frontend/`.

## Développement

### Prérequis

- [Node.js](https://nodejs.org/en/)
- [Yarn](https://classic.yarnpkg.com/en/docs/install)
- [.NET 6](https://dotnet.microsoft.com/download/dotnet/6.0)

### Installation des dépendances

```bash
Il est nécessaire d'installer les dépendances de chaque projet avant de pouvoir les lancer.

**backend**
```bash
cd Backend/Artisashop
dotnet restore
```

**frontend**
```bash
cd Frontend
yarn install
```

### Lancer le projet

> Par simplicité, il est recommandé d'utiliser deux terminaux séparés pour lancer le backend et le frontend.

```bash
# Backend
cd Backend/Artisashop
dotnet run

# Frontend
cd Frontend
yarn start
```

### Accéder à l'application

L'application est accessible à l'adresse [http://localhost:3000](http://localhost:3000).

L'interface Swagger est disponible à l'adresse [https://localhost:7095/swagger](https://localhost:7095/swagger).

## CmaApi and RechercheEntreprisesApi

Ces projets sont générés à l'aide de l'outil openapi-generator-cli (<https://openapi-generator.tech>).

Les spécifications swagger sont `cma.openapi.json` et `recherche-entreprises.openapi.json`.

Les fichiers de configuration sont `cma.openapi.config.yaml` et `recherche-entreprises.openapi.config.yaml`.

Le template de génération est csharp-netcore (<https://openapi-generator.tech/docs/generators/csharp-netcore>).

Pour générer les APIs, utiliser les lignes de commande :

```bash
# CmaApi
openapi-generator-cli.cmd generate -g csharp-netcore -i ./cma.openapi.json -o CmaApi -c ./cma.openapi.config.yaml
```

```bash
# RechercheEntreprisesApi
openapi-generator-cli.cmd generate -g csharp-netcore -i ./recherche-entreprises.openapi.json -o RechercheEntreprisesApi -c ./recherche-entreprises.openapi.config.yaml
```

> Attention, ces clients ne doivent être regénérés qu'en cas de mise à jour de la configuration ou du générateur
> associé.