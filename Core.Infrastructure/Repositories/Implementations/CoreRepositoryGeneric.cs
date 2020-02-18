using System;
using System.Linq;
using System.Linq.Expressions;

using Core.Domain.Entities.Interfaces;
using Core.Domain.Repositories.Interfaces;
using Core.Infrastructure.Persistence.DatabaseContexts.Interfaces;

namespace Core.Infrastructure.Repositories.Implementations
{
    public class CoreRepositoryGeneric<TEntity> : CoreRepository, ICoreRepositoryGeneric<TEntity>
        where TEntity : class, ICoreBaseEntity
    {
        public CoreRepositoryGeneric(ICoreDatabaseContext databaseContext)
            : base(databaseContext)
        {
        }

        public virtual IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate = default)
        {
            var query = DatabaseContext.Set<TEntity>().AsQueryable();
            query = predicate != null ? query.Where(predicate) : query;
            return query;
        }

        public virtual TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            var entity = DatabaseContext.Set<TEntity>().FirstOrDefault(predicate);
            return entity;
        }

        public virtual void Create(TEntity entity)
        {
            var entryEntity = DatabaseContext.Set<TEntity>().Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            var entryEntity = DatabaseContext.Set<TEntity>().Update(entity);
        }

        public virtual void Delete(Guid id)
        {
            var entity = GetFirstOrDefault(x => x.Id == id);
            if (entity != null)
            {
                entity.Deleted = true;
            }
        }
    }
}
