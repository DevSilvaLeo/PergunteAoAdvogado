import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Cliente } from "src/components/cliente/cliente";
import { ApiUrl } from "./url.service";

@Injectable({
    providedIn: 'root'
})

export class ClienteService {
    constructor(private http: HttpClient) {

    }

    public saveOrUpdate(cliente: Cliente){    
        if(cliente.IdCliente){
            return this.http.put<Cliente>(ApiUrl + '/Cliente/', cliente);
        }else{
            return this.http.post<Cliente>(ApiUrl + '/Cliente/', cliente);
        }                
    }

    public getAll(){
        return this.http.get<Cliente[]>(ApiUrl + '/Cliente/');
    }

    public getById(id:number){
        return this.http.get<Cliente>(ApiUrl + '/Cliente/' + id);
    }

    public remove(id:number){
        return this.http.delete(ApiUrl + '/Cliente/' + id)
    }

    

}