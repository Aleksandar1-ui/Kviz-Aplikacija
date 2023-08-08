import { Accordion, AccordionDetails, AccordionSummary, Box, CardMedia, List, ListItem, Typography } from "@mui/material"
import React, { useState } from "react"
import { BASE_URL } from "../api"
import { ExpandCircleDown } from "@mui/icons-material";
import { green, grey, red } from "@mui/material/colors";
export default function Odgovor({odgovori}) {
    const [expanded, setExpanded] = useState(false);
    const promena = (panel) => (event, isExpanded) =>{
        setExpanded(isExpanded ? panel : false);
    };
    const markiranje = (qna, idx) => {
        if([qna.odgovor,(qna.selected+1)].includes(idx)) {
            return {sx: {color : qna.odgovor===idx ? green[500] : red[500]}}
        }
    }
    return(
        <Box sx={{mt:5,width:'100%',maxWidth:640,mx:'auto'}}>
            {
                odgovori.map((item,j) => (
                    <Accordion disableGutters key={j} expanded={expanded === j} onChange={promena(j)}>
                        <AccordionSummary expandIcon={<ExpandCircleDown/>}
                        sx={{
                            color: item.odgovor === item.selected+1 ? green[500] : red[500]
                        }}>
                            <Typography sx={{width:'90%',flexShrink:0}}>
                                {item.prashanje}
                            </Typography>
                        </AccordionSummary>
                        <AccordionDetails sx={{backgroundColor:grey[900]}}>
                            {item.imeSlika ?
                            <CardMedia component="img" image={BASE_URL+'sliki/'+item.imeSlika} sx={
                                {
                                    width:220
                                }
                            } /> : null }
                            <List>
                                {item.opcii.map((x,i) =>
                                <ListItem key={i}>
                                    <Typography {...markiranje(item,(i+1))}>
                                        <b>{String.fromCharCode(65+i)+'. '}</b>{x}
                                    </Typography>
                                </ListItem>)}
                            </List>
                        </AccordionDetails>
                    </Accordion>
                ))
            }
        </Box>
    )
}