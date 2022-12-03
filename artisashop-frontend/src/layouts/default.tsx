import { createRouteConfig, Outlet } from "@tanstack/react-router";
import Navbar from "../components/layout/navbar";

export const layoutRoute = createRouteConfig().addChildren({
    id: "defaultLayout",
    component: DefaultLayout,
});

export default function DefaultLayout() {
    return (
        <div>
            <Navbar />
            <Outlet />
        </div>
    );
}