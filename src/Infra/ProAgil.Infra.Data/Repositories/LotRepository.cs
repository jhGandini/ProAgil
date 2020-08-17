using ProAgil.Domain.Entities;
using ProAgil.Domain.Interfaces;
using ProAgil.Domain.Selectors;
using ProAgil.Infra.Data.Contexts;

namespace ProAgil.Infra.Data.Repositories
{
    public class LotRepository : Repository<Lot, EventSelector>, ILotRepository
    {
        public LotRepository(ProAgilContext context) : base(context) { }
    }
}