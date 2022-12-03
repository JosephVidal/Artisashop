import { lazy } from 'react';
import { createRouteConfig, RouteConfig, RouteOptions } from "@tanstack/react-router"
import { useAtom } from "jotai";
import { z } from "zod";
import { ChatApi } from "../../api";
import useApi from "../../hooks/useApi";
import userAtom from "../../states/atoms/user";

export const chatRouteSearchSchema = z.object({
    userId: z.string().optional(),
});

export const chatRoute = createRouteConfig().createRoute({
    path: "chat",
    component: lazy(() => import("./Chat")),
    validateSearch: chatRouteSearchSchema.parse,
    loader: async ({ search }) => {
        const [me] = useAtom(userAtom);
        const chatApi = useApi(ChatApi);

        return {
            // TODO: create a route to get a chat by a single id (the interlocutor id)
            history: (search.userId && me?.id) ? await chatApi.getConversationHistory({ users: [search.userId, me.id] }) : null,
        }
    },
});

type LoaderDataType<T> = T extends RouteOptions<any, any, any, any, any, infer R> ? R : never;

type TIP = LoaderDataType<typeof chatRoute>;