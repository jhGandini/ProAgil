using ProAgil.Domain.Entities;
using ProAgil.Domain.Selectors;

namespace ProAgil.Domain.Interfaces
{
    public interface IEventRepository : IRepository<Event, EventSelector> { }
}