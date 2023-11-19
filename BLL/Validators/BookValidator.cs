using BLL.Models;
using FluentValidation;

namespace BLL.Validators
{
    public class BookValidator : AbstractValidator<BookDTOModel>
    {
        public BookValidator()
        {
            RuleFor(b => b.Id).NotNull();
            RuleFor(b => b.Title).NotEmpty();
        }
    }
}
