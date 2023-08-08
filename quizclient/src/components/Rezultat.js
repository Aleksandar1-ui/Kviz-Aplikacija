import React, { useEffect, useState } from "react";
import useStateContext from "./hooks/useStateContext";
import { Endpoints, createApiEndpoint } from "../api";
import { Alert, Box, Button, Card, CardContent, CardMedia, Typography } from "@mui/material";
import { getVreme } from "../helper";
import { useNavigate } from "react-router-dom";
import { green } from "@mui/material/colors";
import Odgovor from "./Odgovor";
export default function Rezultat() {
    const{context,setContext} = useStateContext()
    const[poeni, setPoeni] =useState(0)
    const[odgovori, setOdgovori]=useState([])
    const[prikaziAlert,setAlert]=useState(false)
    const navigacija = useNavigate()
    useEffect(() => {
        const ids = context.selektiraniOpcii.map(x => x.prashanjeId)
        createApiEndpoint(Endpoints.GetOdgovori)
        .post(ids)
        .then(res=>{
            const qna = context.selektiraniOpcii
            .map(x => ({
                ...x,
                ...(res.data.find(y => y.prashanjeId==x.prashanjeId))
            }))
            setOdgovori(qna)
            presmetajRezultat(qna)
        })
        .catch(err => console.log(err))
    },[])
    const presmetajRezultat = qna => {
        let rez = qna.reduce((acc,curr)=> {
            return curr.odgovor === (curr.selected+1) ? acc+1 : acc;
        },0)
        setPoeni(rez)
    }
    const restart = () => {
        setContext({
            vreme:0,
            selektiraniOpcii:[]
        })
        navigacija("/kviz")
    }
    const vnesiRezultat = () => {
        createApiEndpoint(Endpoints.Ucesnik)
        .put(context.ucesnikId, {
            ucesnikId : context.ucesnikId,
            vreme : context.vreme,
            poeni : poeni
        })
        .then(res => {
            setAlert(true)
            setTimeout(() => {
                setAlert(false)
            },4000)
        })
        .catch(err => console.log(err))
    }
    return(
        <>
        <Card sx={{mt:5,display:'flex',width:'100%',maxWidth:640,mx:'auto'}}>
            <Box sx={{display:'flex',flexDirection:'column',flexGrow:1}}>
                <CardContent sx={{flex:'1 0 auto',textAlign:'center'}}>
                    <Typography variant="h4">Честитки</Typography>
                    <Typography variant="h6">Освоени поени </Typography>
                    <Typography variant="span" color={green[500]}>{poeni}</Typography>/5
                    <Typography variant="h6">Времетраење : {getVreme(context.vreme)+' минути'}</Typography>
                    <Button variant="contained" sx={{mx:1}} size="small" onClick={vnesiRezultat}>Внеси</Button>
                    <Button variant="contained" sx={{mx:1}} size="small" onClick={restart}>Друг обид</Button>
                    <Alert severity="success" variant="string" sx={{
                        width:'60%', 
                        m:'auto', 
                        visibility: prikaziAlert ? 'visible' : 'hidden'}}>Ажуриран резултат...</Alert>
                </CardContent>
            </Box>
            <CardMedia component="img" sx={{width:220}} image="./trofej.png"/>
        </Card>
        <Odgovor odgovori={odgovori}/>
        </>
    )
}