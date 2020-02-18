using System;
using System.Threading.Tasks;

namespace Core.Domain.Repositories.Interfaces
{
    public interface ICoreUnitOfWork : IDisposable
    {
        Task<int> Commit();
        void Rollback();
    }
}
