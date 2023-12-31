import { AppBar, Button, Container, Toolbar, Typography } from "@mui/material";
import React from "react";
import { Outlet, useNavigate } from "react-router-dom";
import useStateContext from "./hooks/useStateContext";

export default function Layout() {

    const {resetContext} = useStateContext()
    const navigacija = useNavigate()
    const logout = () => {
        resetContext()
        navigacija("/")
    }

    return (
        <>
        <AppBar position="sticky">
            <Toolbar sx={{width:640,m:'auto'}}>
                <Typography variant="h4" align="center" sx={{flexGrow:1}}>
                    Квиз апликација
                </Typography>
                <Button onClick={logout}>Одјави се</Button>
            </Toolbar>
        </AppBar>
        <Container>
            <Outlet/>
        </Container>
        </>
    )
}