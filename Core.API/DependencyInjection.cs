using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCoreAPI(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            return services;
        }
    }
}
