import {NavLink, Outlet} from "react-router-dom";
import {Text, Button} from "@chakra-ui/react";

export default function LayoutAuth() {
    return (
        <>
            <Button m={3} as={NavLink} to="/">Retour</Button>
            <Outlet/>
        </>
    )
}