using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Services.Api.Models.Cliente
{
    public class ClienteCadastroModel
    {
        [Required(ErrorMessage = "Informe o nome para o cadastro")]
        [MaxLength(200, ErrorMessage = "O nome não pode ultrapassar 200 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe um email para o cadastro")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe o telefone do cliente")]
        [MaxLength(16, ErrorMessage = "O telefone celular possui o formato (XX)XXXXX-XXXX")]
        public string Telefone { get; set; }
    }
}
