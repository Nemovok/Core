using System;
using System.Linq;
using System.Reflection;

using AutoMapper;

using Core.Application.Mapping.Interfaces;

namespace Core.Application.Mapping.Profiles
{
    public class CoreMappingProfile : Profile
    {
        public CoreMappingProfile()
        {
            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                .Where(x => x.GetInterfaces().Any(y => y.IsGenericType && y.GetGenericTypeDefinition() == typeof(ICoreMapFrom<>)));

            foreach (var type in types)
            {
                var mappingMethod = type.GetMethod("Mapping")
                    ?? type.GetInterface("IMapFrom`1").GetMethod("Mapping");

                var instance = Activator.CreateInstance(type);
                mappingMethod?.Invoke(instance, new object[] { this });
            }
        }
    }
}
