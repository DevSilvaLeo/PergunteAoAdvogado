import { HttpEventType } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { AlertService } from "src/services/alert.service";
import { QuestionService } from "src/services/pergunta.service";
import { Pergunta } from "../pergunta/pergunta";

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html'
})

export class HomeComponent implements OnInit {
    questionForm : FormGroup;
    pergunta: Pergunta;
    perguntas: Pergunta[] = [];
    progress: number;
    message: string;
    imageSrc: string;
    options = {
        autoClose: true,
        keepAfterRouteChange: false
    };

    constructor(private fb: FormBuilder, private service: QuestionService, private alert: AlertService){
        this.pergunta = new Pergunta();
    }

    listarPerguntas(){
        this.service.getAll().subscribe( 
            res =>{
                console.log(res)
                this.perguntas = res;
        })
    }

    createForm(){
        this.questionForm = this.fb.group({
            titulo: ["", [Validators.required, Validators.minLength(10), Validators.maxLength(150)]],
            descricao: ["", [Validators.required, Validators.minLength(10), Validators.maxLength(500)]],
            anexo: [""],
            file: ["",Validators.required],
            fileSource: ["", Validators.required]
        })
    }

    private getValue(field:string){
        return this.questionForm.controls[field].value
    }

    get f() { return this.questionForm.controls; }

    cadastrar(){
        this.pergunta.Titulo = this.getValue('titulo');
        this.pergunta.Descricao = this.getValue('descricao');
        this.pergunta.Anexo = this.getValue('anexo');
        //console.log(this.pergunta);
        this.service.saveOrUpdate(this.pergunta).subscribe(res=>{
            console.log(res);  
        })  
                
        this.alert.success("Salvo!", this.options)
        this.questionForm.reset();
    }

    uploadFile = (files) =>{
        if (files.length === 0) {
            return;
        }
        let fileToUpload = <File>files[0];
        const formData = new FormData();
        formData.append('file', fileToUpload, fileToUpload.name);

        this.service.upload(formData).subscribe(
            event =>{
                if (event.type === HttpEventType.UploadProgress)
                this.progress = Math.round(100 * event.loaded / event.total);
                else if (event.type === HttpEventType.Response) {
                    console.log(event);
                    console.log(formData);
                this.message = 'Arquivo anexado com sucesso.';
            }
            error =>{
                console.log(error);
            }
        })
    }

    onFileChange(event) {
        const reader = new FileReader();
        
        if(event.target.files && event.target.files.length) {
          const [file] = event.target.files;
          reader.readAsDataURL(file);
        
          reader.onload = () => {
       
            this.imageSrc = reader.result as string;
         
            this.questionForm.patchValue({
              fileSource: reader.result
            });
            
            console.log(reader.result)       
          };       
        }
    }
    
    ngOnInit() {
        this.listarPerguntas();
        this.createForm();
    }
}