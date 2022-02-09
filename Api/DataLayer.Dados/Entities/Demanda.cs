using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Dados.Entities
{
    public class Demanda
    {
        public int IdDemanda { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Anexo { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
