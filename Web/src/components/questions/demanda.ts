export class Demanda {
    IdDemanda: number;
    Titulo: string;
    Descricao: string;
    Anexo: string;

    constructor(id?: number, titulo?: string, descricao?:string, anexo?:string){
        this.IdDemanda = id;
        this.Titulo = titulo;
        this.Descricao = descricao;
        this.Anexo = anexo;
    }
}