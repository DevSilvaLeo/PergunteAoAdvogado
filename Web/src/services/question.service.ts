import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Demanda } from "src/components/questions/demanda";

const ApiUrl = "http://suzaneadvd.jrmendonca.com.br/api/Demanda/"
const UploadUrl = "http://suzaneadvd.jrmendonca.com.br/api/Upload/"
@Injectable({
    providedIn: 'root'
})

export class QuestionService {
    constructor(private http: HttpClient) {

    }

    public saveOrUpdate(demanda: Demanda){
        if(demanda.IdDemanda){
            return this.http.put<Demanda>(ApiUrl, demanda);
        }else{
            return this.http.post<Demanda>(ApiUrl, demanda);
        }
    }


    public getAll(){
        return this.http.get<Demanda>(ApiUrl);
    }

    public getById(id:number){
        return this.http.get<Demanda>(ApiUrl + id);
    }

    public remove(id:number){
        return this.http.delete(ApiUrl + id)
    }



}
