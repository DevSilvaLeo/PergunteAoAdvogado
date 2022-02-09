import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Pergunta } from "src/components/pergunta/pergunta";
import { ApiUrl, UploadUrl } from "./url.service";

@Injectable({
    providedIn: 'root'
})

export class QuestionService {
    constructor(private http: HttpClient) {

    }

    public saveOrUpdate(pergunta: Pergunta){    
        if(pergunta.IdDemanda){
            return this.http.put<Pergunta>(ApiUrl + '/Demanda/', pergunta);
        }else{
            return this.http.post<Pergunta>(ApiUrl + '/Demanda/', pergunta);
        }                
    }

    public getAll(){
        return this.http.get<Pergunta[]>(ApiUrl + '/Demanda/');
    }

    public getById(id:number){
        return this.http.get<Pergunta>(ApiUrl + '/Demanda/' + id);
    }

    public remove(id:number){
        return this.http.delete(ApiUrl + '/Demanda/' + id)
    }

    public upload(formData: FormData){

        return this.http.post("https://localhost:44356/api/Upload", formData, {reportProgress: true, observe: 'events'});
    }
}