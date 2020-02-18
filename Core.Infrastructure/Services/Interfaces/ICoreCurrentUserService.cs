using System;

namespace Core.Infrastructure.Services.Interfaces
{
    public interface ICoreCurrentUserService : ICoreInfrastructureService
    {
        Guid UserId { get; set; }
    }
}
