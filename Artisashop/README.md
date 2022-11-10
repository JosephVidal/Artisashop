# Artisashop

## Migrer la base de données

Lorsque les définitions ou les relations des modèles, il faut créer une migration

### Créer une migration

**bash**

```bash
read -p "Nom de la migration (ex. InitialCreate)" MigrationName
dotnet ef migrations add $MigrationName
```

**powershell**

```bash
$MigrationName = Read-Host -Prompt "Nom de la migration (ex. InitialCreate)"
dotnet ef migrations add $MigrationName
```

### Appliquer une migration

Cette commande applique les migrations sur votre base de données.

```bash
dotnet ef database update
```

### Annuler une migration

```bash
dotnet ef database drop
```

### Autres commandes

#### dotnet ef migrations

```
Usage: dotnet ef migrations [options] [command]

Options:
  -h|--help        Show help information
  -v|--verbose     Show verbose output.
  --no-color       Don't colorize output.
  --prefix-output  Prefix output with level.

Commands:
  add     Adds a new migration.
  bundle  Creates an executable to update the database.
  list    Lists available migrations.
  remove  Removes the last migration.
  script  Generates a SQL script from migrations.
```

#### dotnet ef database

```
Usage: dotnet ef database [options] [command]

Options:
  -h|--help        Show help information
  -v|--verbose     Show verbose output.
  --no-color       Don't colorize output.
  --prefix-output  Prefix output with level.

Commands:
  drop    Drops the database.
  update  Updates the database to a specified migration.
```