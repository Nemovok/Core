using System.Text.Json;

using Core.Infrastructure.Interfaces;

namespace Core.Infrastructure.Services.Implementations
{
    public class CoreJsonDeserializerService : ICoreJsonDeserializerService
    {
        public T Deserialize<T>(string jsonString)
        {
            var @object = JsonSerializer.Deserialize<T>(jsonString);
            return @object;
        }
    }
}
