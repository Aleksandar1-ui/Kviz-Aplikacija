import React from "react";
import useStateContext from "./hooks/useStateContext";
import { Navigate, Outlet } from "react-router-dom";

export default function Avtentikacija() {
    const {context} = useStateContext()
    return (
        context.ucesnikId === 0 ? <Navigate to="/"/> : <Outlet/>
    )
}