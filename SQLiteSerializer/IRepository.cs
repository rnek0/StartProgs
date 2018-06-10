using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace StartProgs.SQLiteSerializer
{
    public interface IRepository : IDisposable
    {
        // Para agregar una nueva entidad a la bd.
        TEntity Create<TEntity>(TEntity toCreate) where TEntity : class;

        // Para eliminar una entidad de la bd.
        bool Delete<TEntity>(TEntity toDelete) where TEntity : class;

        // Para Actualizar una entidad.
        bool Update<TEntity>(TEntity toUpdate) where TEntity : class;

        // Para recuperar una entidad en base a un criterio.
        TEntity Retrieve<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class;

        // Para recuperar un conjunto de entidades
        // que cumplan con un criterio de busqueda.
        List<TEntity> Filter<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class;
    }
}