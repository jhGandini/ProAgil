using System;
using System.Collections.Generic;
using System.Linq;
using ProAgil.Domain.Entities;
using ProAgil.Domain.Interfaces;
using ProAgil.Domain.Selectors;
using ProAgil.Infra.Data.Contexts;

namespace ProAgil.Infra.Data.Repositories
{
    public class EventRepository : Repository<Event, EventSelector>, IEventRepository
    {
        public EventRepository(ProAgilContext context) : base(context) { }

        public override void Add(Event entity)
        {
            try
            {
                _context.Set<Event>().Add(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override IEnumerable<Event> GetList(EventSelector selector, List<string> includes = null)
        {
            try
            {
                if (includes != null && includes.Count > 0)
                {
                    _dbSetQuryable = AddIncludes(_dbSetQuryable, includes);
                }
                
                //_dbSetQuryable = CreateParameters(selector,_dbSetQuryable);

                return CreateParameters(selector,_dbSetQuryable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private IQueryable<Event> CreateParameters(EventSelector selector, IQueryable<Event> query)
        {        
            if (selector.EventId > 0)            
                query = query.Where(x => x.Id.Equals(selector.EventId));            

            if(selector.DateEventIni != null)
            {
                query = query.Where(x => x.DateEvent >= selector.DateEventIni && 
                    x.DateEvent <= ((selector.DateEventFin != null) 
                        ? selector.DateEventFin 
                        : selector.DateEventIni.Value.AddDays(1)));                
            }

            if (!string.IsNullOrEmpty(selector.Theme))            
                query = query.Where(x => x.Theme.ToLower().Contains(selector.Theme.ToLower()));            

            if (selector.Capacity > 0)            
                query = query.Where(x => x.Capacity.Equals(selector.Capacity));            

            if (!string.IsNullOrEmpty(selector.Street))            
                query = query.Where(x => x.Address.Street.ToLower().Contains(selector.Street.ToLower()));  

            if (!string.IsNullOrEmpty(selector.Number))            
                query = query.Where(x => x.Address.Number.ToLower().Contains(selector.Number.ToLower()));  

            if (!string.IsNullOrEmpty(selector.Neigborhood))            
                query = query.Where(x => x.Address.Neigborhood.ToLower().Contains(selector.Neigborhood.ToLower()));  

            if (!string.IsNullOrEmpty(selector.City))            
                query = query.Where(x => x.Address.City.ToLower().Contains(selector.City.ToLower()));  

            if (!string.IsNullOrEmpty(selector.State))            
                query = query.Where(x => x.Address.State.ToLower().Contains(selector.State.ToLower()));  

            if (!string.IsNullOrEmpty(selector.Country))            
                query = query.Where(x => x.Address.Country.ToLower().Contains(selector.Country.ToLower()));  

            if (!string.IsNullOrEmpty(selector.ZipCode))            
                query = query.Where(x => x.Address.ZipCode.ToLower().Contains(selector.ZipCode.ToLower()));      

            if(selector.RegisterDateIni != null)
            {
                query = query.Where(x => x.MaintenanceDate.RegisterDate >= selector.RegisterDateIni && 
                    x.MaintenanceDate.RegisterDate <= ((selector.RegisterDateFin != null) 
                        ? selector.RegisterDateFin 
                        : selector.RegisterDateIni.Value.AddDays(1)));                
            }

            if(selector.LastUpdateDateIni != null)
            {
                query = query.Where(x => x.MaintenanceDate.LastUpdateDate >= selector.LastUpdateDateIni && 
                    x.MaintenanceDate.LastUpdateDate <= ((selector.LastUpdateDateFin != null) 
                        ? selector.LastUpdateDateFin 
                        : selector.LastUpdateDateIni.Value.AddDays(1)));                
            }

            if (selector.EventActive != null)            
                query = query.Where(x => x.Activater.Active.Equals(selector.EventActive));
            else
                query = query.Where(x => x.Activater.Active.Equals(true));

            if (selector.BatchId != null)            
                query = query.Where(x => x.Lots.Any(b => b.Id == selector.BatchId));    
            
            if (selector.BatchActive != null)            
                query = query.Where(x => x.Lots.Any(b => b.Activater.Active.Equals(selector.BatchActive)));

            if (!string.IsNullOrEmpty(selector.BatchDescription))            
                query = query.Where(x => x.Lots.Any(b => b.Description.Equals(selector.BatchDescription)));  

            return query;
        }
    }
}