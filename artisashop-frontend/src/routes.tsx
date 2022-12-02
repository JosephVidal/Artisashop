import { createRoute, createRouteConfig } from "@tanstack/react-router";
import { lazy } from "react";

const Home = lazy(() => import("./pages/index"));

const rootRoute = createRouteConfig();

// /
export const indexRoute = rootRoute.createRoute({ path: "/", component: Home });

// a-propos/
export const aproposRoute = rootRoute.createRoute({ path: "a-propos" });
export const aproposArtisansRoute = aproposRoute.createRoute({ path: "artisans" });
export const aproposPolitiqueConfidentialiteRoute = aproposRoute.createRoute({ path: "politique-confidentialite" });
export const AproposRoute = aproposRoute.addChildren([aproposArtisansRoute, aproposPolitiqueConfidentialiteRoute]);

// produits/
export const produitsRoute = rootRoute.createRoute({ path: "produits" });
export const produitsCreerRoute = produitsRoute.createRoute({ path: "creer", component: Home });
export const produitsReclamationRoute = produitsRoute.createRoute({ path: "reclamation", component: Home });
export const ProduitsRoute = produitsRoute.addChildren([produitsCreerRoute, produitsReclamationRoute]);

// espace-artisan/
export const espaceArtisanRoute = rootRoute.createRoute({ path: "espace-artisan" });
export const espaceArtisanProduitsRoute = espaceArtisanRoute.createRoute({ path: "produits" });
export const espaceArtisanProduitsIdRoute = espaceArtisanProduitsRoute.createRoute({ path: ":id" });
export const EspaceArtisanRoute = espaceArtisanRoute.addChildren([espaceArtisanProduitsRoute, espaceArtisanProduitsIdRoute]);

// artisans/
export const artisansRoute = rootRoute.createRoute({ path: "artisans" });
export const artisansIdRoute = artisansRoute.createRoute({ path: ":id" });
export const ArtisansRoute = artisansRoute.addChildren([artisansIdRoute]);


export const homeRoute = rootRoute.createRoute({ path: "/", component: Home });
export const cartRoute = rootRoute.createRoute({ path: 'cart' });
export const chatRoute = rootRoute.createRoute({ path: 'chat' });
export const craftsmanRoute = rootRoute.createRoute({ path: 'craftsman' });
export const loginRoute = rootRoute.createRoute({ path: 'login' });
export const panierRoute = rootRoute.createRoute({ path: 'panier' });
export const privacyPolicyRoute = rootRoute.createRoute({ path: 'privacy-policy' });
export const productRoute = rootRoute.createRoute({ path: 'product/$id' });
export const profilRoute = rootRoute.createRoute({ path: 'profil' });
export const registerRoute = rootRoute.createRoute({ path: 'register' });
export const searchRoute = rootRoute.createRoute({ path: 'search' });

export const routeConfig = rootRoute.addChildren([
    homeRoute,
    chatRoute,
    cartRoute,
    rootRoute.createRoute({ path: 'auth' })
        .addChildren([loginRoute, registerRoute]),
]);
