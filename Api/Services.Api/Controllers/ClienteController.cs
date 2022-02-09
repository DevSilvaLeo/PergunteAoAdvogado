using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.Api.Models.Cliente;
using DataLayer.Dados.Contracts;
using DataLayer.Dados.Entities;

namespace Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(ClienteCadastroModel model, [FromServices] IClienteRepository rep)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Cliente c = new Cliente();
                    c.Nome = model.Nome;
                    c.Email = model.Email;
                    c.Telefone = model.Telefone;
                    c.DataCadastro = DateTime.Now;

                    rep.Insert(c);

                    return Ok("Cliente cadastrado com sucesso");
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
        public IActionResult Put(ClienteConsultaModel model, [FromServices] IClienteRepository rep)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Cliente c = new Cliente();
                    c.IdCliente = model.IdCliente;
                    c.Nome = model.Nome;
                    c.Email = model.Email;
                    c.Telefone = model.Telefone;

                    rep.Update(c);

                    return Ok("Cliente atualizado com sucesso");
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
        public IActionResult Delete(int id, [FromServices] IClienteRepository rep)
        {
            try
            {
                rep.Delete(id);
                return Ok("Exclusão realizada com sucesso");
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpGet]
        public IActionResult ConsultarTodos([FromServices] IClienteRepository rep)
        {
            try
            {
                var list = new List<Cliente>();
                list = rep.GetAll();

                return Ok(list);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpGet("{id}")]
        public IActionResult ConsultarPorId(int id, [FromServices] IClienteRepository rep)
        {
            try
            {
                var cliente = rep.GetById(id);

                return Ok(cliente);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
            
        }
        
        
    }
}
