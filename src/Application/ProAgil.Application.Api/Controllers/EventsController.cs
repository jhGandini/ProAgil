using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProAgil.Domain.Dtos;
using ProAgil.Domain.Entities;
using ProAgil.Domain.Interfaces;
using ProAgil.Domain.Selectors;
using ProAgil.Domain.ValueObjects;

namespace ProAgil.Application.Api.Controllers
{
    //[Authorize]
    [Route("[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private ILogger<EventsController> _loger;
        private IEventService _eventService;

        public EventsController(ILogger<EventsController> loger, IEventService eventService)
        {
            _loger = loger;
            _eventService = eventService;
        }

        
        [HttpPost("[action]")]
        public IActionResult GetList(EventSelector selector)
        {
            var a = _eventService.GetListEvents(selector);
            //return Ok();
            return Ok(_eventService.GetListEvents(selector));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var dto = _eventService.GetSingleEvent(id);
            if (dto == null)
                return NotFound("Evento não encontrado");

            return Ok(dto);        
        }

        [HttpGet("[action]")]
        public IActionResult GetActives()
        {
            return Ok(_eventService.GetListEventsActives());
        }

        [HttpGet("[action]")]
        public IActionResult GetInactives()
        {
            return Ok(_eventService.GetListEventsInactives());
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _eventService.DeleteEvent(id);
            return Ok();
        }

        [HttpPost]
        public IActionResult Post(EventDto model)
        {
            return Ok(_eventService.RegisterEvent(model));
        }

        [HttpPut]
        public IActionResult Put(EventDto model)
        {
            var _event = _eventService.UpdateEvent(model);
            if (_event.Valid)
                return CreatedAtAction(nameof(Get), new { id = _event.Id }, _event);
            //return Ok(_event);

            return BadRequest(_event);
        }
    }
}