using BLL.Models;
using FluentValidation;

namespace BLL.Validators
{
    public class GenreValidator : AbstractValidator<GenreDTOModel>
    {
        public GenreValidator()
        {
            RuleFor(g => g.Id).NotNull();
            RuleFor(g => g.Name).NotEmpty();
        }
    }
}
