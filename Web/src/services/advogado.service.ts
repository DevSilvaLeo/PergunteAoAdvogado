import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Advogado } from "src/components/advogado/advogado";
import { ApiUrl } from "./url.service";


@Injectable({
    providedIn: 'root'
})

export class AdvogadoService {
    constructor(private http: HttpClient) {

    }

    public saveOrUpdate(advogado: Advogado){    
        if(advogado.IdAvogado){
            return this.http.put<Advogado>(ApiUrl + '/Advogado', advogado);
        }else{
            return this.http.post<Advogado>(ApiUrl + '/Advogado', advogado);
        }                
    }

    public getAll(){
        return this.http.get<Advogado[]>(ApiUrl + '/Advogado');
    }

    public getById(id:number){
        return this.http.get<Advogado>(ApiUrl + '/Advogado' + id);
    }

    public remove(id:number){
        return this.http.delete(ApiUrl + '/Advogado/' + id)
    }

    

}