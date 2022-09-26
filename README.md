# Artichaut

Source for the Artichaut EIP (Epitech Innovative Project).

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

> Attention, ces clients ne doivent être regénérés qu'en cas de mise à jour de la configuration ou du générateur associé.