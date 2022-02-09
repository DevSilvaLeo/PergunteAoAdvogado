import { Component, OnInit } from "@angular/core";
import { AdvogadoService } from "src/services/advogado.service";
import { Advogado } from "../advogado";

@Component({
    selector: 'advogado-consulta',
    templateUrl: './consulta.component.html',
    styleUrls: ['./consulta.component.css']
})

export class AdvogadoConsultaComponent implements OnInit {
    advogados: Advogado[] = [];


    constructor(private service: AdvogadoService){
        
    }

    listaAdvogados(){ 
        this.service.getAll().subscribe(res=>{
            this.advogados = res;
        })
    }
    ngOnInit() {
    }
}