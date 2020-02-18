using Core.Infrastructure.Services.Interfaces;

namespace Core.Infrastructure.Interfaces
{
    public interface ICoreJsonDeserializerService : ICoreInfrastructureService
    {
        T Deserialize<T>(string json);
    }
}
