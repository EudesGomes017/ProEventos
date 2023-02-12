using Data.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class EventoController : ControllerBase
    {


        private readonly DataContext _context;

        public EventoController(DataContext context)
        {
            _context = context;
        }
        //public IEnumerable<Evento> _evento = new Evento[]
        //{
        //        new Evento()
        //        {

        //            EventoId = 1,
        //            Tema = " Angular 11 e DotNetCore 6 ",
        //            Local = " Joinviller ",
        //            Lote = "1",
        //            QtdPessoas = 250,
        //            DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy")
        //        },
        //        new Evento()
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
            return _context.Eventos.Where(Evento => Evento.EventoId == id);
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
