using System;
using System.Threading.Tasks;

using Core.Domain.Repositories.Interfaces;
using Core.Infrastructure.Persistence.DatabaseContexts.Interfaces;

namespace Core.Infrastructure.Repositories.Implementations
{
    public class CoreUnitOfWork : ICoreUnitOfWork
    {
        protected ICoreDatabaseContext DatabaseContext;
        private bool disposed = false;

        public CoreUnitOfWork(ICoreDatabaseContext databaseContext)
        {
            DatabaseContext = databaseContext;
        }

        public virtual async Task<int> Commit()
        {
            var saveChangesAsyncResult = await DatabaseContext.SaveChangesAsync();
            return saveChangesAsyncResult;
        }

        public virtual void Rollback()
        {
            throw new NotImplementedException();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    DatabaseContext.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
