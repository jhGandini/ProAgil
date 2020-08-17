using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Flunt.Notifications;
using ProAgil.Domain.Dtos;
using ProAgil.Domain.Entities;
using ProAgil.Domain.Interfaces;
using ProAgil.Domain.Queries;
using ProAgil.Domain.Selectors;
using ProAgil.Domain.ValueObjects;

namespace ProAgil.Domain.Services
{
    public class EventService : Notifiable, IEventService
    {
        private IUnitOfWork _uow;
        private List<string> includesEvents = new List<string>();
        private IMapper _mapper;

        public EventService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
            includesEvents.Add("Lots");
        }

        public EventDto GetSingleEvent(int id)
        {
            var _event = _uow.EventRepository.GetById(id, includesEvents);
            return _mapper.Map<EventDto>(_event);
        }

        public IEnumerable<EventDto> GetAllEvents()
        {
            var _events = _uow.EventRepository.GetAll(includesEvents);
            var eventsDto = _mapper.Map<IEnumerable<EventDto>>(_events);
            return eventsDto;
        }

        public IEnumerable<EventDto> GetListEvents(EventSelector selector)
        {
            var _events = _uow.EventRepository.GetList(selector, includesEvents);
            var eventsDto = _mapper.Map<IEnumerable<EventDto>>(_events);
            return eventsDto;
        }

        public IEnumerable<EventDto> GetListEventsActives()
        {
            var _events = _uow.EventRepository.Get(EventQueries.SelectorActives, includesEvents);
            var eventsDto = _mapper.Map<IEnumerable<EventDto>>(_events);
            return eventsDto;
        }

        public IEnumerable<EventDto> GetListEventsInactives()
        {
            var _events = _uow.EventRepository.Get(EventQueries.SelectorInactives, includesEvents);
            var eventsDto = _mapper.Map<IEnumerable<EventDto>>(_events);
            return eventsDto;
        }

        public EventDto RegisterEvent(EventDto dto)
        {
            try
            {
                return dto;
                var Event = _mapper.Map<Event>(dto);
                if (Event.Valid)
                {
                    _uow.EventRepository.Add(Event);
                    _uow.Commit();
                }
                return _mapper.Map<EventDto>(Event);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public EventDto UpdateEvent(EventDto dto)
        {
            try
            {
                //##### Manual Create a new Event 
                var Adrress = new Address(dto.Street, dto.Number, dto.Neigborhood, dto.City, dto.State, dto.Country, dto.ZipCode);
                var maintenanceDate = new MaintenanceDate(dto.RegisterDate, dto.LastUpdateDate);
                var activater = new Activater(dto.Active);

                var Event = new Event(dto.Id.Value, Adrress, dto.DateEvent, dto.Theme, dto.Capacity, maintenanceDate, activater);

                var LotRemove = _uow.LotRepository.Get(a => !dto.Lots.Select(c => c.Id).Contains(a.Id) && a.EventId == dto.Id);
                var LotAdd = new List<Lot>();
                var LotUpdate = new List<Lot>();

                foreach (var LotIn in dto.Lots.Where(c => c.Id == 0))
                {
                    var bb = new Lot(null, LotIn.Description, LotIn.CurrentEvent, Event, new Activater(LotIn.Active));

                    AddNotifications(bb);

                    LotAdd.Add(bb);
                }

                foreach (var LotUp in dto.Lots.Where(c => c.Id != 0))
                {
                    var bb = new Lot(LotUp.Id, LotUp.Description, LotUp.CurrentEvent, Event, new Activater(LotUp.Active));
                    LotUpdate.Add(bb);

                    AddNotifications(bb);
                }

                AddNotifications(Event);
                if (Valid)
                {
                    _uow.EventRepository.Update(Event);
                    _uow.LotRepository.DeleteRange(LotRemove);
                    _uow.LotRepository.AddRange(LotAdd);
                    _uow.LotRepository.UpdateRange(LotUpdate);

                    _uow.Commit();
                }

                Event.AddLots(LotUpdate);
                Event.AddLots(LotAdd);

                return _mapper.Map<EventDto>(Event);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteEvent(int id)
        {
            var _event = _uow.EventRepository.GetById(id, null);
            _uow.EventRepository.Delete(_event);
            _uow.Commit();
        }
    }
}


//##### Manual Create a new Event
// var Adrress = new Address(a.Street, a.Number, a.Neigborhood, a.City, a.State, a.Country, a.ZipCode);
// var maintenanceDate = new MaintenanceDate(a.RegisterDate, a.LastUpdateDate);
// var activater = new Activater(a.Active);

// var Event = new Event(null, Adrress, a.DateEvent, a.Theme, a.Capacity, maintenanceDate, activater);

// foreach (var LotDto in a.Lots)
// {
//     Event.AddLot(new Lot(null, LotDto.Description, LotDto.CurrentEvent, null, null));
// }