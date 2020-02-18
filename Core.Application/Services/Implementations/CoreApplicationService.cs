using Core.Application.Services.Interfaces;
using Core.Domain.Repositories.Interfaces;

namespace Core.Application.Services.Implementations
{
    public abstract class CoreApplicationService : ICoreApplicationService
    {
        protected ICoreUnitOfWork UnitOfWork { get; }
        protected ICoreRepository LinkedRepository { get; }

        protected CoreApplicationService(ICoreUnitOfWork unitOfWork, ICoreRepository linkedRepository)
        {
            UnitOfWork = unitOfWork;
            LinkedRepository = linkedRepository;
        }
    }
}
