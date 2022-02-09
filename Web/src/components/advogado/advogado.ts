export class Advogado {
    IdAvogado: number;
    Nome: string;
    InscricaoOAB: string;
    CodSegurancaOAB: string;
    ExpedicaoOAB: string;
    Foto: string;
    Cep:string;
    Logradouro:string;
    Cidade:string;
    Uf:string;
    Bairro:string;
    Complemento:string;
    Especializacao:string;
    Biografia:string

    constructor(idadvogado?: number, nome?: string, inscricaooab?: string, 
        codseguranca?: string, expedicaoab?: string, foto?: string, cep?:string,
         logradouro?:string,cidade?:string,uf?:string, bairro?:string,complemento?:string,especializacao?:string,biografia?:string){

        this.IdAvogado = idadvogado;
        this.Nome = nome;
        this.InscricaoOAB = inscricaooab;
        this.CodSegurancaOAB = codseguranca;
        this.ExpedicaoOAB = expedicaoab;
        this.Foto = foto;
        this.Cep = cep;
        this.Logradouro = logradouro;
        this.Cidade = cidade;
        this.Uf = uf; 
        this.Bairro =bairro; 
        this.Complemento = complemento;
        this.Especializacao=especializacao;
        this.Biografia=biografia;
    }
}