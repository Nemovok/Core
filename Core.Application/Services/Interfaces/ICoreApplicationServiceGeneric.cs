using System;
using System.Linq;
using System.Linq.Expressions;

using Core.Domain.Entities.Interfaces;

namespace Core.Application.Services.Interfaces
{
    public interface ICoreApplicationServiceGeneric<TEntity> : ICoreApplicationService
        where TEntity : class, ICoreBaseEntity
    {
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate = default);
        TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(Guid id);
    }
}
