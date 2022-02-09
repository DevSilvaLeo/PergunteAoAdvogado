export class Cliente {
    IdCliente: number;
    Nome: string;
    Email: string;
    Telefone: string;
    DataCadastro: Date;

    constructor(idcliente?: number, nome?: string, email?: string, telefone?: string, datacadastro?: Date){
        this.IdCliente = idcliente;
        this.Nome = nome;
        this.Email = email;
        this.Telefone = telefone;
        this.DataCadastro = datacadastro;
    }
}