using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Proagil.Domain.Shared.Entities;

namespace ProAgil.Domain.Interfaces
{
    public interface IRepository<TEntity, TSelector> where TEntity : Entity
    {
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);
        TEntity GetById(int id, List<string> includes = null);
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> args, List<string> includes = null);
        IEnumerable<TEntity> GetAll(List<string> includes = null);
        IEnumerable<TEntity> GetList(TSelector selector,List<string> includes = null);
        int Save();
    }
}