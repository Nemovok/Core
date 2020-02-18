using System;
using System.Linq;
using System.Linq.Expressions;

using Core.Application.Services.Interfaces;
using Core.Domain.Entities.Interfaces;
using Core.Domain.Repositories.Interfaces;

namespace Core.Application.Services.Implementations
{
    public class CoreApplicationServiceGeneric<TEntity, TRepository> : CoreApplicationService, ICoreApplicationServiceGeneric<TEntity>
        where TEntity : class, ICoreBaseEntity
        where TRepository : class, ICoreRepositoryGeneric<TEntity>
    {
        protected new TRepository LinkedRepository { get; }

        public CoreApplicationServiceGeneric(ICoreUnitOfWork unitOfWork, TRepository linkedRepository)
            : base(unitOfWork, linkedRepository)
        {
            LinkedRepository = linkedRepository;
        }

        public virtual IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate = default)
        {
            var query = LinkedRepository.Get(predicate);
            return query;
        }

        public virtual TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            var entity = LinkedRepository.GetFirstOrDefault(predicate);
            return entity;
        }

        public virtual void Create(TEntity entity)
        {
            LinkedRepository.Create(entity);
        }

        public virtual void Update(TEntity entity)
        {
            LinkedRepository.Update(entity);
        }

        public virtual void Delete(Guid id)
        {
            LinkedRepository.Delete(id);
        }
    }
}
