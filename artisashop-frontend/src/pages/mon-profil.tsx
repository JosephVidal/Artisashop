import { createRouteConfig } from "@tanstack/react-router"

export const indexRoute = createRouteConfig().createRoute({ path: "/", component: Home });

export default function ProfilePage() {
    return (
        <div>
            <h1 className="text-8xl font-blackfort">
                Mon profil
            </h1>
            <p>
                Mon profil
            </p>
        </div>
    )
}