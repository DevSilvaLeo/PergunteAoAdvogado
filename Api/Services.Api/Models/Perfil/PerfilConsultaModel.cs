using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Services.Api.Models.Perfil
{
    public class PerfilConsultaModel
    {
        public int IdPerfil { get; set; }

        [Required(ErrorMessage = "É preciso escrever uma biografia")]
        [MinLength(30, ErrorMessage = "A biografia deve possuir pelo menos 30 caracteres")]
        [MaxLength(500, ErrorMessage = "A biografia não deve ultrapassar 500 caracteres")]
        public string Biografia { get; set; }

        [Required(ErrorMessage = "Informe sua especialização")]
        public string Especializacao { get; set; }
        public DateTime ModificadoEm { get; set; }
    }
}
