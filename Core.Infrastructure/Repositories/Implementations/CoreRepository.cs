using Core.Domain.Repositories.Interfaces;
using Core.Infrastructure.Persistence.DatabaseContexts.Interfaces;

namespace Core.Infrastructure.Repositories.Implementations
{
    public class CoreRepository : ICoreRepository
    {
        protected ICoreDatabaseContext DatabaseContext { get; }

        public CoreRepository(ICoreDatabaseContext databaseContext)
        {
            DatabaseContext = databaseContext;
        }
    }
}
