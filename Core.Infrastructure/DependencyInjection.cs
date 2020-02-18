using Core.Domain.Repositories.Interfaces;
using Core.Infrastructure.Interfaces;
using Core.Infrastructure.Repositories.Implementations;
using Core.Infrastructure.Services.Implementations;
using Core.Infrastructure.Services.Interfaces;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Core.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCoreInfrastructure(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            services.TryAddScoped<ICoreUnitOfWork, CoreUnitOfWork>();

            services.TryAddTransient<ICoreCurrentUserService, CoreCurrentUserService>();
            services.TryAddTransient<ICoreDateTimeOffsetService, CoreDateTimeOffsetService>();
            services.TryAddTransient<ICoreJsonSerializerService, CoreJsonSerializerService>();
            services.TryAddTransient<ICoreJsonDeserializerService, CoreJsonDeserializerService>();
            services.TryAddTransient<ICoreHistoryWriterService, CoreHistoryWriterService>();

            services.TryAddTransient(typeof(ICoreRepositoryGeneric<>), typeof(CoreRepositoryGeneric<>));

            return services;
        }
    }
}
