using System;

using Core.Infrastructure.Services.Interfaces;

namespace Core.Infrastructure.Services.Implementations
{
    public class CoreCurrentUserService : ICoreCurrentUserService
    {
        public Guid UserId { get; set; }
    }
}
