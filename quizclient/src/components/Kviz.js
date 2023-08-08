import React, { useContext, useEffect, useState } from "react";
import useStateContext from "./hooks/useStateContext";
import { BASE_URL, Endpoints, createApiEndpoint } from "../api";
import { Box, Card, CardContent, CardHeader, CardMedia, LinearProgress, List, ListItemButton, Typography } from "@mui/material";
import { getVreme } from "../helper";
import { useNavigate } from "react-router-dom";

export default function Kviz() {

    const [prasanje,setPrasanje] = useState([])
    const [prIndeks, setPrIndeks] = useState(0)
    const [vreme, setVreme] = useState(0)
    const {context, setContext} = useStateContext()
    const navigacija = useNavigate()
    let timer;

    const startTimer = () => {
        timer = setInterval(() => {
            setVreme((k) => k+1)
        },[1000])
    }

useEffect(() => {
    setContext({
        vreme:0,
        selektiraniOpcii:[]
    })
    createApiEndpoint(Endpoints.Prashanja)
    .fetch()
    .then((res)=> {
        setPrasanje(res.data)
        startTimer()
    })
    .catch((err)=>{
        console.log(err);
    })
    return () => {clearInterval(timer)}
},[])

const azurirajOdgovor = (prashanjeId,indeks) => {
    const temp=[...context.selektiraniOpcii]
    temp.push({
        prashanjeId,
        selected:indeks
    })
    if(prIndeks<4) {
        setContext({selektiraniOpcii:[...temp]})
        setPrIndeks(prIndeks+1)
    }
    else {
        setContext({selektiraniOpcii:[...temp], vreme})
        navigacija("/rezultat")
    }
}

    return(
       prasanje.length!=0?
       <Card sx={{maxWidth:640,mx:'auto',mt:5,'& .MuiCardHeader-action':{m:0,alignSelf:'center'}}}>
        <CardHeader title={'Prashanje '+(prIndeks+1)+' od 5'} action={<Typography>{getVreme(vreme)}</Typography>}/>
        <Box>
            <LinearProgress variant="determinate" value={(prIndeks+1)*100/5}/>
        </Box>
        {prasanje[prIndeks].imeSlika!=null ? <CardMedia
         component="img" 
         image={BASE_URL+'sliki/'+prasanje[prIndeks].imeSlika} sx={{width:220}}/>
         : null}
        <CardContent>
            <Typography variant="h6">
                {prasanje[prIndeks].prashanje}
            </Typography>
            <List>
                {prasanje[prIndeks].opcii.map((item,idx) =>
                <ListItemButton key={idx} disableRipple onClick={()=> azurirajOdgovor(prasanje[prIndeks].prashanjeId,idx)}>
                    <div>
                        <b>{String.fromCharCode(65+idx)+" . "}</b>{item}
                    </div>
                </ListItemButton>)}
            </List>
        </CardContent>
       </Card> : null
    )
}