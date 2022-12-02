# Artisashop

> Artisashop est un marketplace pour les artisans d'art.  
> Le projet est réalisé dans le cadre du Projet Innovatif EPITECH (EIP).

Frontend d'Artisashop en React, basé sur le framework [vite](https://vitejs.dev/).

## Utilisation

### Prérequis

-   [Node.js](https://nodejs.org/en/)
-   [Yarn](https://yarnpkg.com/lang/en/) [version 3.0.0 ou supérieure](https://yarnpkg.com/getting-started/install#updating-to-the-latest-versions)

### Installation

```bash
yarn install
```

### Lancement

```bash
yarn dev
```

Le site est accessible à l'adresse [http://localhost:5173](http://localhost:3000).

Le HMR fait que les changements sont pris en compte sans avoir à relancer le serveur.

### Construire le projet

```bash
yarn build
```

## Architecture

Le projet est basé sur le framework [vite](https://vitejs.dev/).
Il utilise la librairie de routing *type-safe* de [Tanstack Router](https://tanstack.com/router/v1).

### `public`

Contient les fichiers statiques du projet, tels que les logos, images, fontes, etc.

### `src/api/`

Contient le client généré via [OpenAPI Generator](https://openapi-generator.tech/) pour l'API Artisashop.

### `src/assets`

Contient les fichiers statiques du projet importés dans le code (ex: les icones).

> NOTE: La raison pour laquelle les icones sont stockées directement en SVG dans le code est que cela garantie une taille de bundle plus petite, et de mieux voir quelles icons sont utilisées.  
> Voir https://github.com/react-icons/react-icons/issues/289

### `src/components`

Contient les composants React réutilisables.

### `src/pages`

Contient les pages du site.

La nommenclature des pages est inspirée de [Next.js](https://nextjs.org/docs/basic-features/pages) et de [l'exemple de tanstack-router](https://github.com/TanStack/router/tree/beta/examples/react/kitchen-sink-codesplit) pour l'utilisation granulaire de son routeur.

Le nommage des pages doit tendre à suivre le format de Next.js, c'est-à-dire `nom-de-la-page.tsx` pour les pages simples et `nom-de-la-page/[id].tsx` pour les pages avec des paramètres. `index.tsx` est la page par défaut (`nom-de-la-page/index.tsx`).
Pour plus d'info sur la nommenclature des pages, voir [la documentation de Next.js](https://nextjs.org/docs/routing/introduction).

Dans le cas où une page a besoin d'être chargée dynamiquement, il faut utiliser la fonction `lazy` de React et faire du code-splitting comme dans l'exemple ci-dessous, [inspiré par celui-ci](https://github.com/TanStack/router/tree/beta/examples/react/kitchen-sink-codesplit/src/routes/expensive).

```yaml
src/pages/mon-profil:
    - index.tsx
    - MonProfil.tsx
```

```tsx
// src/pages/mon-profil/index.tsx
import { lazy } from "react";
import { createRouteConfig } from "@tanstack/react-router";

export const MonProfilPage = lazy(() => import("./MonProfil"));

export const monProfilRoute = createRouteConfig().createRoute({
    path: "/mon-profil",
    component: MonProfilPage,
});
```

```tsx
// src/pages/mon-profil/MonProfil.tsx
export default function ProfilePage() {
    return (
        <div>
            {/* ... */}
        </div>
    )
}
```

### `src/states`

Contient les états de l'application, tels que les données de l'utilisateur connecté, les données du panier, etc.

### `src/conf.ts`

Contient les variables d'environnement du projet.

Les variables d'environnement sont chargées à partir du fichier `.env` à la racine du projet, et des variables d'environnement du système.

Selon la variable d'environnement `NODE_ENV`, les variables d'environnement sont chargées de la manière suivante:

-   `NODE_ENV=development`: les variables d'environnement sont chargées depuis le fichier `.env` à la racine du projet, et les variables d'environnement du système.
-   `NODE_ENV=production`: les variables d'environnement sont chargées depuis les variables d'environnement du système (injectées depuis un `.env.production` en local, ou dans l'environnement par la CI de Github).

Contrairement à Create React App, les variables d'environnement ne sont pas préfixées par `REACT_APP_`, mais par `VITE_`.

### `src/routes.ts`

Contient les routes assemblées du site.

### Fichiers de configuration

-   `vite.config.ts` : configuration de Vite
-   `tailwind.config.js` : configuration de TailwindCSS
-   `tsconfig.json` : configuration de TypeScript
-   `.eslintrc.js` : configuration de ESLint

### TODO & Lignes directrices

-  Quand Tanstack Router sera stable et complet...
    - utiliser le server-side rendering <https://github.com/vitejs/awesome-vite#ssr>
    - utiliser le preloading <https://tanstack.com/router/v1/docs/guide/preloading>
- Utiliser le code-splitting pour toutes les pages.
