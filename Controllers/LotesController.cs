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
    public class LoteController : ControllerBase
    {

        private readonly ILoteController _loteController;

        public LoteController(ILoteController loteController)
        {
            _loteController = loteController;
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

        [HttpGet("{eventoId}")]
        public async Task<IActionResult> Get(int eventoId) //IActionResult permit retorna os status codes do http
        {
            try
            {
                var eventos = await _loteController.GetEventoByIdAsync(true); //retorna sempre os participantes
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

        [HttpPut("{eventoId}")]
        public async Task<IActionResult> Put(int eventoId, LoteDto[] models)
        {
            try
            {
                var evento = await _loteController.UpDateEvento(id, models);
                if (evento == null) return NoContent(); //Conteudo não foi encontrado

                return Ok(evento); //Ok status code 200
            }
            catch (Exception e)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar evento. Erro: {e.Message}");
            }
        }

        [HttpDelete("{eventoid}/{loteId}")]
        public async Task<IActionResult> Delete(int eventoId, int loteId)
        {
            try
            {
                var eventos = await _loteController.GetEventoByIdAsync(true); //retorna sempre os participantes
                if (eventos == null)
                {
                    return NoContent(); //Conteudo não foi encontrado
                }

                return await _loteController.DeleteEvento(id) ? Ok("Deletedo com sucesso! ") :
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
