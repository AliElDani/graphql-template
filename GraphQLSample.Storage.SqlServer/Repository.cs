using GraphQLSample.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GraphQLSample.Storage.SqlServer
{
    public class Repository<TDbContext> : IRepository where TDbContext : DbContext
    {
        private readonly TDbContext _context;

        public Repository(TDbContext context)
        {
            _context = context;
        }

        public TEntity GetById<TId, TEntity>(TId id) where TEntity : class
        {
            return _context.Set<TEntity>().Find(id);
        }

        public ICanEagerlyFetch<TEntity> GetAll<TEntity>() where TEntity : class
        {
            return new EagerFetch<TEntity>(_context.Set<TEntity>());
        }

        public ICanEagerlyFetch<TEntity> Find<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return new EagerFetch<TEntity>(_context.Set<TEntity>().Where(predicate));
        }

        public TEntity Add<TEntity>(TEntity entity) where TEntity : class
        {
            _context.Set<TEntity>().Add(entity);
            return entity;
        }

        public IEnumerable<TEntity> AddRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            var entityValues = entities.ToList();
            _context.Set<TEntity>().AddRange(entityValues);
            return entityValues;
        }

        public TEntity Update<TEntity>(TEntity entity) where TEntity : class
        {
            _context.Set<TEntity>().Update(entity);
            return entity;
        }

        public TEntity Delete<TEntity>(TEntity entity) where TEntity : class
        {
            _context.Remove(entity);
            return entity;
        }

        private class EagerFetch<TEntity> : ICanEagerlyFetch<TEntity> where TEntity : class
        {
            private IQueryable<TEntity> _query;

            public EagerFetch(IQueryable<TEntity> query)
            {
                _query = query;
            }

            public ICanEagerlyFetch<TEntity> Include<TProperty>(Expression<Func<TEntity, TProperty>> path)
            {
                _query = _query.Include(path);
                return this;
            }

            public IEnumerator<TEntity> GetEnumerator()
            {
                return _query.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public Expression Expression => _query.Expression;

            public Type ElementType => _query.ElementType;

            public IQueryProvider Provider => _query.Provider;
        }
    }
}
