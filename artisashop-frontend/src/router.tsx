import { createRoute, createRouteConfig } from "@tanstack/react-router";
import { lazy } from "react";
import { rootRoute } from "./pages/__root";

const routeConfig = rootRoute.addChildren([
    // indexRoute,
    // authRoute,
    // adminRoute,
    // profilRoute,
]);