using System.Threading;
using System.Threading.Tasks;

using Core.Infrastructure.Services.Interfaces;

using MediatR.Pipeline;

using Microsoft.Extensions.Logging;

namespace Core.Application.Behaviours.Implementations
{
    public class CoreRequestLogger<TRequest> : IRequestPreProcessor<TRequest>
    {
        protected ILogger<TRequest> Logger { get; }
        protected ICoreCurrentUserService CurrentUserService { get; }

        public CoreRequestLogger(
            ILogger<TRequest> logger,
            ICoreCurrentUserService currentUserService)
        {
            Logger = logger;
            CurrentUserService = currentUserService;
        }

        public virtual async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            Logger.LogInformation("{@Request} {UserId}", request, CurrentUserService.UserId);
        }
    }
}
