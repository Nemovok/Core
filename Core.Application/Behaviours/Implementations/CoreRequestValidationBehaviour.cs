using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using FluentValidation;

using MediatR;

namespace Core.Application.Behaviours.Implementations
{
    public class CoreRequestValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TRequest>
        where TRequest : IRequest<TResponse>
    {
        protected IEnumerable<IValidator<TRequest>> Validators { get; }

        public CoreRequestValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            Validators = validators;
        }

        public virtual async Task<TRequest> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TRequest> next)
        {
            var validationContext = new ValidationContext(request);
            var failures = Validators.Select(x => x.Validate(validationContext)).SelectMany(x => x.Errors).Where(x => x != null).ToList();

            if (failures.Count > 0)
            {
                throw new ValidationException(failures);
            }

            var response = await next();
            return response;
        }
    }
}
