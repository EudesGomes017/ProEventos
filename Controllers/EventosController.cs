using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Persistence.Context;
using ProEventos.Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class EventosController : ControllerBase
    {


        private readonly IEventosServices _eventosServices;

        public EventosController(IEventosServices eventosServices)
        {
            _eventosServices = eventosServices;
        }
        //public IEnumerable<Eventos> _evento = new Eventos[]
        //{
        //        new Eventos()
        //        {

        //            EventoId = 1,
        //            Tema = " Angular 11 e DotNetCore 6 ",
        //            Local = " Joinviller ",
        //            Lote = "1",
        //            QtdPessoas = 250,
        //            DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy")
        //        },
        //        new Eventos()
        //        {

        //            EventoId = 2,
        //            Tema = " Angular 11 e DotNetCore 6 ",
        //            Local = " São Paulo ",
        //            Lote = "2",
        //            QtdPessoas = 350,
        //            DataEvento = DateTime.Now.AddDays(3).ToString("dd/MM/yyyy")
        //        }
        //    };
      
        [HttpGet]
        public async Task<IActionResult> Get() //IActionResult permit retorna os status codes do http
        {
            try
            {
                var eventos = await _eventosServices.GetAllEventosAsync(true); //retorna sempre os participantes
                if (eventos == null)
                {
                    return NotFound("Nenhum evento encontrado. "); //NotFound() status code 404
                }
                return Ok(eventos); //Ok status code 200
            }
            catch (Exception e)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar evento. Eroo: {e.Message}");
            }
        }


        [HttpGet("{tema}/tema")]
        public async Task<IActionResult> GetByTema(string tema) //IActionResult permit retorna os status codes do http
        {
            try
            {
                var eventos = await _eventosServices.GetAllEventosByTemaAsync(tema, true); //retorna sempre os participantes
                if (eventos == null)
                {
                    return NotFound("Eventos por Tema não encontrado"); //NotFound() status code 404
                }
                return Ok(eventos); //Ok status code 200
            }
            catch (Exception e)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar evento. Eroo: {e.Message}");
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var evento = await _eventosServices.GetEventoByIdAsync(id, true); //retorna sempre os participantes
                if (evento == null)
                {
                    return NotFound("Nenhum evento encontrado por Id. "); //NotFound() status code 404
                }
                return Ok(evento); //Ok status code 200
            }
            catch (Exception e)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar evento. Eroo: {e.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Evento model)
        {
            try
            {
                var evento = await _eventosServices.AddEventos(model);
                {
                    return BadRequest(" Erro ao tentar adicionar eventos ");
                }

                return Ok(evento); //Ok status code 200
            }
            catch (Exception e)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar evento. Eroo: {e.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Evento model)
        {
            try
            {
                var evento = await _eventosServices.UpDateEvento(id, model);
                {
                    return BadRequest(" Erro ao tentar adicionar eventos ");
                }

                return Ok(evento); //Ok status code 200
            }
            catch (Exception e)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar evento. Eroo: {e.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
              
                if ( await _eventosServices.DeleteEvento(id))
                {
                    return Ok("Deletedo com sucesso! ");
                }
                else  return BadRequest("Evento não deletado");
             
            }
            catch (Exception e)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar Deletar evento. Eroo: {e.Message}");
            }
        }
    }
}
