using System;
using System.Linq;

using Core.Application.Services.Interfaces;
using Core.Domain.Entities.Interfaces;

namespace Core.API.Controllers.Api
{
    public abstract class CoreApiControllerGeneric<TEntity, TService> : CoreApiController
        where TEntity : class, ICoreBaseEntity
        where TService : class, ICoreApplicationServiceGeneric<TEntity>
    {
        protected TService LinkedService { get; }

        protected CoreApiControllerGeneric(TService linkedService)
        {
            LinkedService = linkedService;
        }

        public virtual IQueryable<TEntity> Get()
        {
            var query = LinkedService.Get();
            return query;
        }

        public virtual TEntity Get(Guid id)
        {
            var entity = LinkedService.GetFirstOrDefault(x => x.Id == id);
            return entity;
        }

        public virtual void Post(TEntity model)
        {
            LinkedService.Create(model);
        }

        public virtual void Put(TEntity model)
        {
            LinkedService.Update(model);
        }

        public virtual void Delete(Guid id)
        {
            LinkedService.Delete(id);
        }
    }
}
