using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Dados.Contracts;
using DataLayer.Dados.Entities;
using Services.Api.Models.Advogado;

namespace Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvogadoController : ControllerBase
    {
        [HttpPost]
        public IActionResult Cadastro(AdvogadoCadastroModel model, [FromServices] IAdvogadoRepository rep)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Advogado a = new Advogado();
                    a.Nome = model.Nome;
                    a.InscricaoOAB = model.InscricaoOAB;
                    a.ExpedicaoOAB = model.ExpedicaoOAB;
                    a.CodSegurancaOAB = model.CodSegurancaOAB;
                    a.Foto = model.Foto;
                    a.CEP = model.CEP;
                    a.Bairro = model.Bairro;
                    a.Logradouro = model.Logradouro;
                    a.Cidade = model.Cidade;
                    a.UF = model.UF;
                    a.Biografia = model.Biografia;
                    a.Complemento = model.Complemento;
                    a.Especializacao = model.Especializacao;
                    a.DataCadastro = DateTime.Now;

                    rep.Insert(a);

                    return Ok("Advogado cadastrado com sucesso");
                }
                catch(Exception e)
                {
                    return StatusCode(500, e.Message);
                }
            }
            else
            {
                return BadRequest("Ocorreram erros de validação");
            }
        }

        [HttpPut]
        public IActionResult Atualiza(AdvogadoConsultaModel model, [FromServices] IAdvogadoRepository rep)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Advogado a = new Advogado();
                    a.IdAdvogado = model.IdAdvogado;
                    a.Nome = model.Nome;
                    a.InscricaoOAB = model.InscricaoOAB;
                    a.ExpedicaoOAB = model.ExpedicaoOAB;
                    a.CodSegurancaOAB = model.CodSegurancaOAB;
                    a.CEP = model.CEP;
                    a.Bairro = model.Bairro;
                    a.Logradouro = model.Logradouro;
                    a.Cidade = model.Cidade;
                    a.UF = model.UF;
                    a.Biografia = model.Biografia;
                    a.Complemento = model.Complemento;
                    a.Especializacao = model.Especializacao;
                    a.Foto = model.Foto;

                    rep.Update(a);

                    return Ok("Advogado atualizado com sucesso");
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }
            }
            else
            {
                return BadRequest("Ocorreram erros de validação");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id, [FromServices] IAdvogadoRepository rep)
        {
            try
            {
                rep.Delete(id);
                return Ok("Advogado removido com sucesso");
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult Consultar([FromServices] IAdvogadoRepository rep)
        {
            try
            {
                var advogados = rep.GetAll();
                return Ok(advogados);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult ConsultaPorId(int id, [FromServices] IAdvogadoRepository rep)
        {
            try
            {
                var advogado = rep.GetById(id);
                return Ok(advogado);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
