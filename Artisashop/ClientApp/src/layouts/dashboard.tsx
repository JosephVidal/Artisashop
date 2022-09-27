import {Outlet} from "react-router-dom";
import Nav from "../components/layout/navbar";
import Footer from "../components/layout/footer";
import {Box} from "@chakra-ui/react";

export default function LayoutDashboard() {
    return (
        <>
            <Nav/>
            <Box p={5}>
                <Outlet/>
            </Box>
            <Footer/>
        </>
    )
}