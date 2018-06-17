using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace StartProgs.Entities
{
    public interface IRepository : IDisposable
    {
        // ADD ENTITY
        TEntity Create<TEntity>(TEntity toCreate) where TEntity : class;

        // DEL ENTITY
        bool Delete<TEntity>(TEntity toDelete) where TEntity : class;

        // UPDATE ENTITY
        bool Update<TEntity>(TEntity toUpdate) where TEntity : class;

        // READ ENTITY
        TEntity Retrieve<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class;

        // List & return entities by filter.
        List<TEntity> Filter<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class;
    }
}