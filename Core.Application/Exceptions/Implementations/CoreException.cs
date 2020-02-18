using System;

using Core.Application.Exceptions.Interfaces;

namespace Core.Application.Exceptions.Implementations
{
    public abstract class CoreException : Exception, ICoreException
    {
        protected CoreException(string message)
            : base(message)
        {

        }
    }
}
