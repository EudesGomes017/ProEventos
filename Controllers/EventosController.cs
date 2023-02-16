using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Persistence.Context;
using System.Collections.Generic;
using System.Linq;

namespace ProEventos.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class EventosController : ControllerBase
    {


        private readonly ProEventosContext _context;

        public EventosController(ProEventosContext context)
        {
            _context = context;
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
        public IEnumerable<Evento> Get()
        {
            return _context.Eventos ;
        }

        [HttpGet("{id}")]
        public IEnumerable<Evento> GetById(int id)
        {
            return _context.Eventos.Where(Evento => Evento.Id == id);
        }

        [HttpPost]
        public string Post()
        {
            return "Exemplo";
        }

        [HttpPut("{id}")]
        public string Put(int id)
        {
            return "Put";
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return "Delted";
        }
    }
}
