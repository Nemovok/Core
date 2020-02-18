using System;
using System.Linq;
using System.Linq.Expressions;

using Core.Domain.Entities.Interfaces;


namespace Core.Domain.Repositories.Interfaces
{
    public interface ICoreRepositoryGeneric<TEntity> : ICoreRepository
        where TEntity : class, ICoreBaseEntity
    {
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate = default);
        TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(Guid id);
    }
}
