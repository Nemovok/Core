using Core.Application.Behaviours.Implementations;
using Core.Application.Services.Implementations;
using Core.Application.Services.Interfaces;

using MediatR;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Core.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCoreApplication(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            services.TryAddTransient(typeof(IPipelineBehavior<,>), typeof(CoreRequestPerformanceBehaviour<,>));
            services.TryAddTransient(typeof(IPipelineBehavior<,>), typeof(CoreRequestValidationBehaviour<,>));
            services.TryAddTransient(typeof(ICoreApplicationServiceGeneric<>), typeof(CoreApplicationServiceGeneric<,>));

            return services;
        }
    }
}
