using System;
using System.Threading;
using System.Threading.Tasks;

using Core.Application.Behaviours.Interfaces;

using MediatR;

namespace Core.Application.Commands.Handlers
{
    public class CoreCommand<T> : ICoreRequest<T>
    {
        public class CoreCommandHandler<TRequest> : ICoreRequestHandler<TRequest>
            where TRequest : IRequest<Unit>
        {
            public CoreCommandHandler()
            {
            }

            public virtual Task<Unit> Handle(TRequest request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
