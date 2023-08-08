import React, { useEffect, useState } from "react";
import { TextField, Button, Box, Card, CardContent, Typography} from "@mui/material";
import Center from "./Center";
import useForm from "./hooks/useForm";
import { Endpoints, createApiEndpoint } from "../api";
import useStateContext from "./hooks/useStateContext";
import { useNavigate } from "react-router-dom";

const getFreshModel = () => ({
    ime:'',
    email:'',
    prezime:'',
    lozinka:'',
})

export default function Login() {
    const {context, setContext, resetContext} = useStateContext();
    const navigacija = useNavigate();
    const {
        values,
        setValues,
        errors,
        setErrors,
        handleInputChange
    } = useForm(getFreshModel);

    useEffect(()=>{
        resetContext()
    },[])

    const login = (e) => {
        e.preventDefault();
        if(validate())
        createApiEndpoint(Endpoints.Ucesnik).post(values)
        .then((res) => { setContext({ucesnikId: res.data.ucesnikId})
        navigacija('/kviz')
    })
         .catch((err) => console.log(err)) 
    }

    const validate = () => {
        let temp = {};
        temp.email = (/\S+@\S+\.\S+/).test(values.email) ? "" : "Невалидна емаил адреса.";
        temp.ime = values.ime !== "" ? "" : "Задолжително поле за пополнување.";
        temp.prezime = values.prezime !== "" ? "" : "Задолжително поле за пополнување.";
        temp.lozinka = values.lozinka !== "" ? "" : "Задолжително поле за пополнување.";
        setErrors(temp);
        return Object.values(temp).every(x => x === "");
    }
    

    return(
        <Center>
            <Card sx={{width:400}}>
                <CardContent sx={{textAlign:'center'}}>
                    <Typography variant="h3" sx={{my:3}}>Квиз апликација</Typography>
                    <Box sx={{
                            '& .MuiTextField-root':{
                            margin:1,
                            width:'90%'
                        }
                    }}>
                        <form noValidate autoComplete="on" onSubmit={login}>
                            <TextField label="E-адреса" name="email" value={values.email} onChange={handleInputChange} variant="outlined" {...(errors.email && {error:true, helperText:errors.email})}/>
                            <TextField label="Име" name="ime" value={values.ime} onChange={handleInputChange} variant="outlined" {...(errors.ime && {error:true, helperText:errors.ime})}/>
                            <TextField label="Презиме" name="prezime" value={values.prezime} onChange={handleInputChange} variant="outlined" {...(errors.prezime && {error:true, helperText:errors.prezime})}/>
                            <TextField label="Лозинка" name="lozinka" value={values.lozinka} onChange={handleInputChange} type="password" variant="outlined" {...(errors.lozinka && {error:true, helperText:errors.lozinka})}/>
                            <Button type="submit" name="kopce" id="kopce" variant="contained" size="large" sx={{width:'90%'}}>Влез</Button>
                        </form>
                    </Box>
                </CardContent>
            </Card>
        </Center>
    )
}
