using ProAgil.Domain.Entities;
using ProAgil.Domain.Selectors;

namespace ProAgil.Domain.Interfaces
{
    public interface ILotRepository : IRepository<Lot,EventSelector> { }
}