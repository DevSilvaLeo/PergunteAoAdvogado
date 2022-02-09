import { Component, OnInit } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { AlertService } from "src/services/alert.service";
import { ClienteService } from "src/services/cliente.service";
import { Cliente } from "../cliente";

@Component({
    selector: 'cadastro-cliente',
    templateUrl: './cadastro.component.html',
    styleUrls: ['./cadastro.component.css']
})

export class CadastroClienteComponent implements OnInit {
    cliente: Cliente;
    clientes: Cliente[] = [];
    cadastroClienteForm: FormGroup;
    options = {
        autoClose: true,
        keepAfterRouteChange: false
    };

    constructor(private fb: FormBuilder, private service: ClienteService, private alert: AlertService){
        this.cliente = new Cliente();
    }

    createForm(){
        this.cadastroClienteForm = this.fb.group({
            nome: ["", [Validators.required, Validators.minLength(10), Validators.maxLength(150)]],
            email: ["", [Validators.required, Validators.email]],
            telefone: ["", [Validators.required, Validators.pattern("^[0-9]*$"), Validators.minLength(10), Validators.maxLength(11)]]
        })
    }

    get f() { return this.cadastroClienteForm.controls; }

    private getValue(field:string){
        return this.cadastroClienteForm.controls[field].value
    }


    salvar(){
        this.cliente.Nome = this.getValue('nome');
        this.cliente.Email = this.getValue('email');
        this.cliente.Telefone = this.getValue('telefone');

        this.service.saveOrUpdate(this.cliente)
            .subscribe(resp=>{
                console.log(resp);
            })

        this.alert.success("Salvo", this.options);
        this.cadastroClienteForm.reset();
        this.listarTodos();
    }

    listarTodos(){
        this.service.getAll().subscribe(res=>{
            this.clientes = res;
        })
    }


    ngOnInit() {
        this.createForm();
        this.listarTodos();
    }
}