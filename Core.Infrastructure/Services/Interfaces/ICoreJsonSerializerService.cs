using Core.Domain.Services.Interfaces;

namespace Core.Infrastructure.Services.Interfaces
{
    public interface ICoreJsonSerializerService : ICoreDomainService
    {
        string Serialize(object @object);
    }
}
