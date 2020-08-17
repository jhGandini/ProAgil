using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProAgil.WebApi.Model;

namespace ProAgil.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly Evento[] Eventos = new Evento[]
        {
            new Evento(){ 
                EventoId = 1,
                Local = "teste", 
                DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"), 
                Tema= "teste", 
                QtdPessoas= 10, 
                Lote = "l1" 
                },
            new Evento(){ 
                EventoId = 2,
                Local = "teste 2", 
                DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"), 
                Tema = "teste 2", 
                QtdPessoas = 11, 
                Lote = "l2" 
                },
            new Evento(){ 
                EventoId = 3,
                Local = "teste 3", 
                DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"), 
                Tema = "teste 3", 
                QtdPessoas = 13, 
                Lote = "l3" 
                }
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public Evento[] Get()
        {            
            return Eventos;
        }

        [HttpGet("{id}")]
        public Evento Get(int id)
        {            
            return Eventos.ToList().FirstOrDefault(x => x.EventoId == id);
        }
    }
}
