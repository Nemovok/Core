
using FluentValidation;

namespace Core.Application.Commands.Validators
{
    public class CoreCommandValidator<TViewModel> : AbstractValidator<TViewModel>
    {
        public CoreCommandValidator()
        {
        }
    }
}
