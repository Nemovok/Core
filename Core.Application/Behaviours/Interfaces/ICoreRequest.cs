
using MediatR;

namespace Core.Application.Behaviours.Interfaces
{
    public interface ICoreRequest<TResponse> : IRequest<TResponse>
    {
    }
}
