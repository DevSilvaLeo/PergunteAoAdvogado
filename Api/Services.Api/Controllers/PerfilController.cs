using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Dados.Contracts;
using DataLayer.Dados.Entities;
using Services.Api.Models.Perfil;

namespace Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        [HttpPost]
        public IActionResult Cadastrar(PerfilCadastroModel model, [FromServices] IPerfilRepository rep)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Perfil p = new Perfil();
                    p.Biografia = model.Biografia;
                    p.Especializacao = model.Especializacao;
                    p.CriadoEm = DateTime.Now;
                    p.ModificadoEm = DateTime.Now;

                    rep.Insert(p);
                    return Ok("Perfil cadastrado com sucesso");
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
        
        [HttpPut]
        public IActionResult Atualizar(PerfilConsultaModel model, [FromServices] IPerfilRepository rep)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Perfil p = new Perfil();
                    p.IdPerfil = model.IdPerfil;
                    p.Biografia = model.Biografia;
                    p.Especializacao = model.Especializacao;
                    p.ModificadoEm = DateTime.Now;

                    rep.Insert(p);
                    return Ok("Perfil cadastrado com sucesso");
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
        public IActionResult Apagar(int id, [FromServices] IPerfilRepository rep)
        {
            try
            {
                rep.Delete(id);

                return Ok("Perfil Deletado");
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult ConsultarTodos([FromServices] IPerfilRepository rep)
        {
            try
            {
                var perfis = rep.GetAll();
                return Ok(perfis);
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult ConsultarPorId(int id, [FromServices] IPerfilRepository rep)
        {
            try
            {
                var perfil = rep.GetById(id);
                return Ok(perfil);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
