using System;

namespace Core.Application.Exceptions.Implementations
{
    public abstract class CoreEntityNotFoundException : CoreException
    {
        protected CoreEntityNotFoundException(Type entityType, object key)
            : base($"Entity \"{entityType.Name}\" with key \"{key}\" was not found.")
        {
        }
    }
}
