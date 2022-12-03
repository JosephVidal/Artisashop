import { useMatch } from "@tanstack/react-router"

import { chatRoute, chatRouteSearchSchema } from ".";
import { ChatMessage } from "../../api";

chatRouteSearchSchema.parse;

export default function Chat() {
    const {
        loaderData: { history },
        search: { userId },
        Link,
        MatchRoute,
        navigate,
    } = useMatch(chatRoute.id);

    return (
        <div>
            <h1 className="text-8xl font-bold">
                Chat
            </h1>
            <p>
                Chat
            </p>
            {history?.map((message : ) => (
                <div key={message.id}>
                    {message.content}
                </div>
            ))}
        </div>
    )
}