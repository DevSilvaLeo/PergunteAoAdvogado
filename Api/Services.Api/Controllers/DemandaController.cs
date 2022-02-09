using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Dados.Contracts;
using DataLayer.Dados.Entities;
using Services.Api.Models.Demanda;

namespace Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemandaController : ControllerBase
    {
        [HttpPost]
        public IActionResult Cadastrar(DemandaCadastroModel model, [FromServices] IDemandaRepository rep) 
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Demanda d = new Demanda();

                    d.Titulo = model.Titulo;
                    d.Descricao = model.Descricao;
                    d.Anexo = model.Anexo;
                    d.DataCadastro = DateTime.Now;

                    rep.Insert(d);

                    return Ok("Demanda cadastrada com sucesso");
                    
                }
                catch(Exception e)
                {
                    return StatusCode(500, e.Message);
                }
            }
            else
            {
                return BadRequest("Ocorreram erros de validação.");
            }
        }

        [HttpPut]
        public IActionResult Atualizar(DemandaConsultaModel model, [FromServices] IDemandaRepository rep)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Demanda d = new Demanda();

                    d.IdDemanda = model.IdDemanda;
                    d.Titulo = model.Titulo;
                    d.Descricao = model.Descricao;
                    d.Anexo = model.Anexo;

                    rep.Update(d);

                    return Ok("Demanda atualizada com sucesso");
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

        [HttpDelete("{id}")]
        public IActionResult Apagar(int id, [FromServices] IDemandaRepository rep)
        {
            try
            {
                rep.Delete(id);
                return Ok("Demanda deletada com sucesso");

            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult Consultar([FromServices] IDemandaRepository rep)
        {
            //var demandas = new List<Demanda>();
            //demandas = rep.GetAll();
            var demandas = rep.GetAll();
            return Ok(demandas);
        }

        [HttpGet("{id}")]
        public IActionResult ConsultarPorId(int id, [FromServices] IDemandaRepository rep)
        {
            var demanda = rep.GetById(id);

            return Ok(demanda);
        }
    }
}
