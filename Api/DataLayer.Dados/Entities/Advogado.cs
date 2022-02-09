using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Dados.Entities
{
    public class Advogado
    {
        public int IdAdvogado { get; set; }
        public string Nome { get; set; }
        public string InscricaoOAB { get; set; }
        public string CodSegurancaOAB { get; set; }
        public string ExpedicaoOAB { get; set; }
        public string Foto { get; set; }
        public DateTime DataCadastro { get; set; }

        public string CEP { get; set; }
        public string Bairro  { get; set; }
        public string  Logradouro { get; set; }
        public string Cidade   { get; set; }
        public string  UF { get; set; }
        public string Biografia { get; set; }
        public string Complemento { get; set; }
        public string Especializacao { get; set; }
    }
}
