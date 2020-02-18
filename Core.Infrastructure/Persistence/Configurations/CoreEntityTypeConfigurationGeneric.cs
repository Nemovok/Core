using Core.Domain.Entities.Interfaces;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Infrastructure.Persistence.Configurations
{
    public abstract class CoreEntityTypeConfigurationGeneric<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : class, ICoreBaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
        }
    }
}
