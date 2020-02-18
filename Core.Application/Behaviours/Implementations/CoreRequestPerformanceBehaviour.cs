using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

using Core.Infrastructure.Services.Interfaces;

using MediatR;

using Microsoft.Extensions.Logging;

namespace Core.Application.Behaviours.Implementations
{
    public class CoreRequestPerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        protected ILogger<TRequest> Logger { get; }
        protected ICoreCurrentUserService CurrentUser { get; }
        protected Stopwatch Stopwatch { get; }

        public CoreRequestPerformanceBehaviour(
            ILogger<TRequest> logger,
            ICoreCurrentUserService currentUser)
        {
            Logger = logger;
            CurrentUser = currentUser;
        }

        public virtual async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            Stopwatch.Start();
            var response = await next();
            Stopwatch.Stop();

            Logger.LogInformation("{@Request} {ElapsedMilliseconds} {UserId}", request, Stopwatch.ElapsedMilliseconds, CurrentUser.UserId);

            return response;
        }
    }
}
