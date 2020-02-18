using System.Collections.Generic;
using System.Threading.Tasks;

using Core.Infrastructure.Services.Interfaces;

using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Core.Infrastructure.Services.Implementations
{
    public class CoreHistoryWriterService : ICoreHistoryWriterService
    {
        public async Task Write(IEnumerable<EntityEntry> entityEntries)
        {
        }
    }
}
