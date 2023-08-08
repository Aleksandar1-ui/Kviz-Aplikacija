import axios from "axios";
export const BASE_URL = 'http://localhost:5195/';
export const Endpoints = {
    Ucesnik:'Ucesnik',
    Prashanja:'Prashanja',
    GetOdgovori:'Prashanja/GetOdgovori'
}
export const createApiEndpoint = endpoint => {
    let url = BASE_URL+'api/'+endpoint+'/';
    return {
        fetch : () => axios.get(url),
        fetchById: id => axios.get(url+id),
        post: novRekord => axios.post(url,novRekord),
        put: (id,azuriranRekord) => axios.put(url+id,azuriranRekord),
        delete: id => axios.delete(url+id),
    }
}