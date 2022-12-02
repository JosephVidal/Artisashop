import { createRouteConfig } from "@tanstack/react-router";
import { lazy } from "react";

export const monProfilRoute = createRouteConfig().createRoute({
    path: "/mon-profil",
    component: lazy(() => import("./MonProfil")),
});