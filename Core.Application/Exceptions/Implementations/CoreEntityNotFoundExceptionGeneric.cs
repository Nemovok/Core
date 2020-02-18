namespace Core.Application.Exceptions.Implementations
{
    public class CoreEntityNotFoundExceptionGeneric<TEntity> : CoreEntityNotFoundException
    {
        public CoreEntityNotFoundExceptionGeneric(object key)
            : base(typeof(TEntity), key)
        {
        }
    }
}
