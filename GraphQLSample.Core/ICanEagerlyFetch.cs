using System;
using System.Linq;
using System.Linq.Expressions;

namespace GraphQLSample.Core
{
    public interface ICanEagerlyFetch<TEntity> : IQueryable<TEntity> where TEntity : class
    {
        ICanEagerlyFetch<TEntity> Include<TProperty>(Expression<Func<TEntity, TProperty>> path);
    }
}
