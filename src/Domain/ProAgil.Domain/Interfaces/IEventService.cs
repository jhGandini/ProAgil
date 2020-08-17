using System.Collections.Generic;
using ProAgil.Domain.Dtos;
using ProAgil.Domain.Entities;
using ProAgil.Domain.Selectors;

namespace ProAgil.Domain.Interfaces
{
    public interface IEventService
    {
        EventDto RegisterEvent(EventDto entity);
        EventDto GetSingleEvent(int id);
        IEnumerable<EventDto> GetAllEvents();
        IEnumerable<EventDto> GetListEvents(EventSelector selector);
        IEnumerable<EventDto> GetListEventsActives();
        IEnumerable<EventDto> GetListEventsInactives();
        EventDto UpdateEvent(EventDto entity);
        void DeleteEvent(int id);

    }
}