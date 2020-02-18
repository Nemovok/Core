using System.Collections.Generic;
using System.Linq;

namespace Core.Application.Models
{
    public class CoreResult<TResult>
    {
        public bool Succeeded { get; }
        public IEnumerable<string> Errors { get; }
        public TResult Result { get; }

        private CoreResult(bool succeeded, TResult result, IEnumerable<string> errors)
        {
            Succeeded = succeeded;
            Result = result;
            Errors = errors;
        }

        public static CoreResult<TResult> Success(TResult result)
        {
            return new CoreResult<TResult>(true, result, Enumerable.Empty<string>());
        }

        public static CoreResult<TResult> Failure(IEnumerable<string> errors)
        {
            return new CoreResult<TResult>(false, default(TResult), errors);
        }
    }
}
