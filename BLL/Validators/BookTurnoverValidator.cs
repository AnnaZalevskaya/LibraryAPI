using BLL.Models;
using FluentValidation;

namespace BLL.Validators
{
    public class BookTurnoverValidator : AbstractValidator<BookTurnoverDTOModel>
    {
        public BookTurnoverValidator()
        {
            RuleFor(bt => bt.Id).NotNull();
            RuleFor(bt => bt.Book).NotNull();
            RuleFor(bt => bt.UserId).NotNull();
        }
    }
}
