using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Services.Api.Models.Demanda
{
    public class DemandaCadastroModel
    {
        [Required(ErrorMessage = "A solicitação precisa de um título")]
        [MaxLength(50, ErrorMessage = "O título deverá ter no máximo 50 caracteres")]
        [MinLength(10, ErrorMessage = "O título deve ter no mínimo 10 caracteres")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "E necessário uma descrição para a solicitação")]
        [MaxLength(500, ErrorMessage = "A descrição não pode ultrapassar o limite de 500 caracteres")]
        [MinLength(50, ErrorMessage = "A descrição precisa ter no minimo 50 caracteres")]
        public string Descricao { get; set; }

        public string Anexo { get; set; }
    }
}
