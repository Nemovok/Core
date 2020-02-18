using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

using Core.Domain.Entities.Interfaces;
using Core.Infrastructure.Identity.Entities;
using Core.Infrastructure.Persistence.DatabaseContexts.Interfaces;
using Core.Infrastructure.Services.Interfaces;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Core.Infrastructure.Persistence.DatabaseContexts.Implementations
{
    public abstract class CoreIdentityDatabaseContext : IdentityDbContext<CoreIdentityUser, CoreIdentityRole, Guid, CoreIdentityUserClaim,
        CoreIdentityUserRole, CoreIdentityUserLogin, CoreIdentityRoleClaim, CoreIdentityUserToken>, ICoreIdentityDatabaseContext
    {
        protected ICoreHistoryWriterService HistoryWriterService { get; }
        protected ICoreDateTimeOffsetService DateTimeOffsetService { get; }
        protected ICoreCurrentUserService CurrentUserService { get; }
        protected IConfiguration Configuration { get; }

        protected CoreIdentityDatabaseContext(DbContextOptions options)
            : base(options)
        {
        }

        protected CoreIdentityDatabaseContext(
            DbContextOptions options,
            IConfiguration configuration,
            ICoreHistoryWriterService historyWriterService,
            ICoreDateTimeOffsetService dateTimeOffsetService,
            ICoreCurrentUserService currentUserService)
            : base(options)
        {
            Configuration = configuration;
            HistoryWriterService = historyWriterService;
            DateTimeOffsetService = dateTimeOffsetService;
            CurrentUserService = currentUserService;
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entityEntries = ChangeTracker.Entries<ICoreBaseEntity>();
            foreach (var entityEntry in entityEntries)
            {
                switch (entityEntry.State)
                {
                    case EntityState.Added:
                        OnEntityStateAdded(entityEntry.Entity);
                        break;
                    case EntityState.Modified:
                        OnEntityStateModified(entityEntry.Entity);
                        break;
                    case EntityState.Deleted:
                        OnEntityStateDeleted(entityEntry.Entity);
                        break;
                    case EntityState.Detached:
                        OnEntityStateDetached(entityEntry.Entity);
                        break;
                    case EntityState.Unchanged:
                        OnEntityStateUnchanged(entityEntry.Entity);
                        break;
                }
            }

            var saveChangesAsyncResult = await base.SaveChangesAsync(cancellationToken);
            if (saveChangesAsyncResult > 0)
            {
                await HistoryWriterService.Write(entityEntries);
            }

            return saveChangesAsyncResult;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        private void OnEntityStateAdded(ICoreBaseEntity entity)
        {
            entity.CreatedDate = DateTimeOffsetService.Now;
            entity.CreatedBy = CurrentUserService.UserId;
        }

        private void OnEntityStateModified(ICoreBaseEntity entity)
        {
            if (entity.Deleted)
            {
                entity.DeletedDate = DateTimeOffsetService.Now;
                entity.DeletedBy = CurrentUserService.UserId;
            }

            entity.ModifiedDate = DateTimeOffsetService.Now;
            entity.ModifiedBy = CurrentUserService.UserId;
        }

        private void OnEntityStateDeleted(ICoreBaseEntity entity)
        {
        }

        private void OnEntityStateDetached(ICoreBaseEntity entity)
        {
        }

        private void OnEntityStateUnchanged(ICoreBaseEntity entity)
        {
        }
    }
}
