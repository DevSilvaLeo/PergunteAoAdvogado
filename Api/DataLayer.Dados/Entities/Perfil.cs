using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Dados.Entities
{
    public class Perfil
    {
        public int IdPerfil { get; set; }
        public string Biografia { get; set; }
        public string Especializacao { get; set; }
        public string Avaliacao { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime ModificadoEm { get; set; }

    }
}
