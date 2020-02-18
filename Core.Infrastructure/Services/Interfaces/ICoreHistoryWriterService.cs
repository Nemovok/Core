using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Core.Infrastructure.Services.Interfaces
{
    public interface ICoreHistoryWriterService : ICoreInfrastructureService
    {
        Task Write(IEnumerable<EntityEntry> entityEntries);
    }
}
