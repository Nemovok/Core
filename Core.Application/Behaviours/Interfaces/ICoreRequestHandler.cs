
using MediatR;

namespace Core.Application.Behaviours.Interfaces
{
    public interface ICoreRequestHandler<TRequest> : IRequestHandler<TRequest>
        where TRequest : IRequest<Unit>
    {
    }
}
