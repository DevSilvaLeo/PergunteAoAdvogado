import { Component, OnInit } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { AdvogadoService } from "src/services/advogado.service";
import { AlertService } from "src/services/alert.service";
import { CepServiceService } from "src/services/cep-service.service";
import { Advogado } from "../advogado";

@Component({
    selector: 'app-advogado',
    templateUrl: './cadastro.component.html',
    styleUrls: ['./cadastro.component.css']
})


export class AdvogadoCadastroComponent implements OnInit{
    advogadoForm: FormGroup;
    advogado: Advogado;
    advogados: Advogado[] = [];
    options = {
        autoClose: true,
        keepAfterRouteChange: false
    };

    constructor(private fb: FormBuilder, private service: AdvogadoService, private alert: AlertService, 
               private cepService:CepServiceService){
        this.advogado = new Advogado();
    }

    consultaCep(){
        this.cepService.buscar(this.getValue('cep')).subscribe((dados)=> this.popularForm(dados));
    }
    popularForm(dados){
        //console.log(dados);
        //patchValue
        this.advogadoForm.patchValue({
            logradouro: dados.logradouro,
            bairro: dados.bairro,
            cidade: dados.localidade,
            uf: dados.uf
        })
    }


    createForm(){
        this.advogadoForm = this.fb.group({
            nome: ["", [Validators.required, Validators.minLength(10), Validators.maxLength(100)]],
            inscricaoOab: ["", [Validators.required, Validators.minLength(10), Validators.maxLength(11)]],
            codSeguranca: ["", [Validators.minLength(10), Validators.maxLength(20)]],
            dataExpedicao: ["", Validators.required],
            cep:["",Validators.required],
            bairro:["",Validators.required],
            logradouro:["",Validators.required],
            cidade:["",Validators.required],
            uf:["",Validators.required],
            biografia:["",Validators.required],
            complemento:["", Validators.required],
            especializacao:["", Validators.required]
        })
    }

    private getValue(field:string){
        return this.advogadoForm.controls[field].value
    }

    get f() { return this.advogadoForm.controls; }

    cadastrar(){
        //this.advogado = new Advogado();
        this.advogado.Nome = this.getValue('nome');
        this.advogado.InscricaoOAB = this.getValue('inscricaoOab');
        this.advogado.CodSegurancaOAB = this.getValue('codSeguranca');
        this.advogado.ExpedicaoOAB = this.getValue('dataExpedicao');
        this.advogado.Cep = this.getValue('cep');
        this.advogado.Logradouro = this.getValue('logradouro');
        this.advogado.Cidade = this.getValue('cidade');
        this.advogado.Bairro = this.getValue('bairro');
        this.advogado.Complemento = this.getValue('complemento');
        this.advogado.Especializacao = this.getValue('especializacao');
        this.advogado.Biografia = this.getValue('biografia');
        this.advogado.Uf = this.getValue('uf');
        this.advogado.Foto = '1';
        console.log(this.advogado);
        
        this.service.saveOrUpdate(this.advogado).subscribe(
            resp=>{
                //console.log(resp); 
            }
        )
        
        this.advogadoForm.reset();
        this.alert.success("Salvo", this.options);          
        this.listaAdvogados();
    }

    listaAdvogados(){ 
        this.service.getAll().subscribe(res=>{
            this.advogados = res;
        })
    }


     



    
    ngOnInit() {
        this.createForm();
        this.listaAdvogados();
    }
    
}