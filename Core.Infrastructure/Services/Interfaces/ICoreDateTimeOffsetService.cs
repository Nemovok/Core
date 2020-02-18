using System;

namespace Core.Infrastructure.Services.Interfaces
{
    public interface ICoreDateTimeOffsetService : ICoreInfrastructureService
    {
        public DateTimeOffset Now { get => DateTimeOffset.Now; }
    }
}
