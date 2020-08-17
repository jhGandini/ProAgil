using ProAgil.Domain.Interfaces;
using ProAgil.Infra.Data.Contexts;
using ProAgil.Infra.Data.Repositories;

namespace ProAgil.Infra.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        protected ProAgilContext _context;

        public UnitOfWork(ProAgilContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            //_disposed = false;
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        #region Repositories

        private IEventRepository _eventRepository;
        private ILotRepository _LotRepository;

        public IEventRepository EventRepository
        {
            get
            {
                if (_eventRepository == null)
                {
                    _eventRepository = new EventRepository(_context);
                }
                return _eventRepository;
            }
        }

        public ILotRepository LotRepository
        {
            get
            {
                if (_LotRepository == null)
                {
                    _LotRepository = new LotRepository(_context);
                }
                return _LotRepository;
            }
        }

        #endregion
    }
}