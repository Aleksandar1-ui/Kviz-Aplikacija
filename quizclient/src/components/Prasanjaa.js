import React, { useContext } from "react";
import useStateContext from "./hooks/useStateContext";

export default function Prasanjaa() {

    const {context, setContext} = useStateContext()
    
    return(
        <div>Prashanja</div>
    )
}