using Proagil.Domain.Shared.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System;
using ProAgil.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using ProAgil.Domain.Interfaces;

namespace ProAgil.Infra.Data.Repositories
{
    public class Repository<TEntity, TSelector> : IRepository<TEntity, TSelector> where TEntity : Entity
    {
        protected readonly ProAgilContext _context;
        protected IQueryable<TEntity> _dbSetQuryable;
        public Repository(ProAgilContext context)
        {
            _context = context;
            _dbSetQuryable = _context.Set<TEntity>().AsQueryable();
        }

        public virtual void Add(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Add(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            try
            {
                _context.Set<TEntity>().AddRange(entities);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(TEntity entity)
        {
            try
            {
                //_context.Set<TEntity>().Attach(entity);
                //_context.Entry(entity).State = EntityState.Modified;
                _context.Update(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            try
            {
                foreach (var entity in entities)
                    _context.Update(entity);
                //_context.Entry(entity).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Remove(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            try
            {
                _context.Set<TEntity>().RemoveRange(entities);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> args, List<string> includes = null)
        {
            try
            {
                if (includes != null && includes.Count > 0)
                {
                    _dbSetQuryable = AddIncludes(_dbSetQuryable, includes);
                }
                return _dbSetQuryable.Where(args);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<TEntity> GetAll(List<string> includes = null)
        {
            try
            {
                if (includes != null && includes.Count > 0)
                {
                    _dbSetQuryable = AddIncludes(_dbSetQuryable, includes);
                }
                return _dbSetQuryable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual IEnumerable<TEntity> GetList(TSelector selector, List<string> includes = null)
        {
            try
            {
                if (includes != null && includes.Count > 0)
                {
                    _dbSetQuryable = AddIncludes(_dbSetQuryable, includes);
                }
                return _dbSetQuryable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public TEntity GetById(int id, List<string> includes = null)
        {
            try
            {
                if (includes != null && includes.Count > 0)
                {
                    _dbSetQuryable = AddIncludes(_dbSetQuryable, includes);
                }
                return _dbSetQuryable.FirstOrDefault(e => e.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual int Save()
        {
            return _context.SaveChanges();
        }

        protected IQueryable<TEntity> AddIncludes(IQueryable<TEntity> query, List<string> includes)
        {
            IQueryable<TEntity> nQuery = null;
            foreach (string include in includes)
            {
                nQuery = query.Include(include);
            }
            return nQuery;
        }


    }
}