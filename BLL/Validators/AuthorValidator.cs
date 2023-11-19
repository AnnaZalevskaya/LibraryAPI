using BLL.Models;
using FluentValidation;

namespace BLL.Validators
{
    public class AuthorValidator : AbstractValidator<AuthorDTOModel>
    {
        public AuthorValidator()
        {
            RuleFor(a => a.Id).NotNull();
            RuleFor(a => a.FullName).NotEmpty();
        }
    }
}
