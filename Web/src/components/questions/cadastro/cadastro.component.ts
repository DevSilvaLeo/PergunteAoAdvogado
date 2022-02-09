import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { QuestionService } from "src/services/question.service";
import { Demanda } from "../demanda";
import {HttpClient} from "@angular/common/http";

@Component({
    selector: 'question-cadastro',
    templateUrl: './cadastro.component.html'
})

export class QuestionCadastroComponent implements OnInit {
    questionForm : FormGroup;
    demanda: Demanda;

    constructor(private fb: FormBuilder, private service: QuestionService, private http:HttpClient){
        this.demanda = new Demanda();
    }

    uploadFile = (files) => {
        if (files.length === 0) {
          return;
        }
        let fileToUpload = <File>files[0];
        const formData = new FormData();
        formData.append('file', fileToUpload, fileToUpload.name);
        this.http.post('http://suzaneadvd.jrmendonca.com.br/api/upload', formData, {reportProgress: true, observe: 'events'})
          .subscribe(event => {
              console.log(event)
            /*if (event.type === HttpEventType.UploadProgress)
             // this.progress = Math.round(100 * event.loaded / event.total);
            else if (event.type === HttpEventType.Response) {
              //this.message = 'Upload success.';
             // this.onUploadFinished.emit(event.body);
            }*/
          });
      }


    createForm(){
        this.questionForm = this.fb.group({
            titulo: ["", [Validators.required, Validators.minLength(10), Validators.maxLength(150)]],
            descricao: ["", [Validators.required, Validators.minLength(50), Validators.maxLength(500)]],
            anexo: [""]
        })
    }

    private getValue(field:string){
        return this.questionForm.controls[field].value
    }

    get f() { return this.questionForm.controls; }

    cadastrar(){
        this.demanda.Titulo = this.getValue('titulo');
        this.demanda.Descricao = this.getValue('descricao');
        this.demanda.Anexo = this.getValue('anexo');
        console.log(this.demanda);
        this.service.saveOrUpdate(this.demanda).subscribe(res=>{
            console.log(res);
        })
        this.questionForm.reset();
    }

    ngOnInit() {
        this.createForm();
    }
}
