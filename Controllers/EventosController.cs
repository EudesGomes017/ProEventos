using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProEventosApplicationServices.Dtos;
using ProEventosApplicationServices.Interfaces;
using System;
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
                    return NoContent(); //Conteudo não foi encontrado
                }

                return Ok(eventos); //Ok status code 200
            }
            catch (Exception e)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar evento. Erro: {e.Message}");
            }
        }

        [HttpGet("{tema}/tema")]
        public async Task<IActionResult> GetByTema(string tema) //IActionResult permit retorna os status codes do http
        {
            try
            {
                var eventos = await _eventosServices.GetAllEventosByTemaAsync(tema, true); //retorna sempre os participantes
                if (eventos == null) return NotFound("Nenhum evento por Temas encontrados. ");
                {
                    return NoContent(); //Conteudo não foi encontrado
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
                if (evento == null) return NotFound("Nenhum evento por Id encontrado. ");
                {
                    return NoContent(); //Conteudo não foi encontrado
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
        public async Task<IActionResult> Post(EventoDto model)
        {
            try
            {
                var evento = await _eventosServices.AddEventos(model);
                if (evento == null) return NoContent(); //Conteudo não foi encontrado;

                return Ok(evento); //Ok status code 200
            }
            catch (Exception e)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar evento. Eroo: {e.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, EventoDto model)
        {
            try
            {
                var evento = await _eventosServices.UpDateEvento(id, model);
                if (evento == null) return NoContent(); //Conteudo não foi encontrado

                return Ok(evento); //Ok status code 200
            }
            catch (Exception e)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar evento. Erro: {e.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var eventos = await _eventosServices.GetAllEventosAsync(true); //retorna sempre os participantes
                if (eventos == null)
                {
                    return NoContent(); //Conteudo não foi encontrado
                }

                return await _eventosServices.DeleteEvento(id) ? Ok("Deletedo com sucesso! ") :
                           throw new Exception("Ocorreu um problema não específico ao tentar deletar o Evento! ");

            }
            catch (Exception e)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar Deletar evento. Eroo: {e.Message}");
            }
        }
    }
}
