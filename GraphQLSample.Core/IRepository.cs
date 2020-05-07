using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GraphQLSample.Core
{
    public interface IRepository
    {
        TEntity GetById<TId, TEntity>(TId id) where TEntity : class;

        ICanEagerlyFetch<TEntity> GetAll<TEntity>() where TEntity : class;

        ICanEagerlyFetch<TEntity> Find<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;

        TEntity Add<TEntity>(TEntity entity) where TEntity : class;

        IEnumerable<TEntity> AddRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;

        TEntity Delete<TEntity>(TEntity entity) where TEntity : class;

        TEntity Update<TEntity>(TEntity entity) where TEntity : class;
    }
}
