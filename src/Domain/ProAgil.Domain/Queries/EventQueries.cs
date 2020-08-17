using System;
using System.Linq.Expressions;
using ProAgil.Domain.Entities;

namespace ProAgil.Domain.Queries
{
    public static class EventQueries
    {
        public static Expression<Func<Event, bool>> SelectorActives = (e => e.Activater.Active.Value == true);
        public static Expression<Func<Event, bool>> SelectorInactives = (e => e.Activater.Active.Value == false);
    }
}