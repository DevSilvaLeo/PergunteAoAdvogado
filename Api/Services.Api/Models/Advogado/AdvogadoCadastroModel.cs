using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Services.Api.Models.Advogado
{
    public class AdvogadoCadastroModel
    {
        [Required(ErrorMessage = "O nome deverá ser preenchido")]
        [MaxLength(150, ErrorMessage = "O campo só recebe até 150 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A incrição da OAB deverá ser preenchida")]
        [MaxLength(10, ErrorMessage = "O campo só recebe até 10 caracteres")]
        [MinLength(5, ErrorMessage = "O campo precisa de no mínimo 5 caracteres")]
        public string InscricaoOAB { get; set; }

        public string CodSegurancaOAB { get; set; }

        [Required(ErrorMessage = "A data de emissão deverá ser informada")]
        public string ExpedicaoOAB { get; set; }
        public string Foto { get; set; }

        public string CEP { get; set; }
        public string Bairro { get; set; }
        public string Logradouro { get; set; }
        public string Cidade { get; set; }

        public string UF   { get; set; }

        public string Biografia { get; set; }

        public string Complemento { get; set; }
        public string Especializacao { get; set; }
    }
}
