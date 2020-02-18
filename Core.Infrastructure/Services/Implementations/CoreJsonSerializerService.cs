using System.Text.Json;

using Core.Infrastructure.Services.Interfaces;

namespace Core.Infrastructure.Services.Implementations
{
    public class CoreJsonSerializerService : ICoreJsonSerializerService
    {
        public string Serialize(object @object)
        {
            var jsonString = JsonSerializer.Serialize(@object);
            return jsonString;
        }
    }
}
