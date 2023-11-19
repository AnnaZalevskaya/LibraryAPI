using BLL.Models.Identity;
using FluentValidation;
using System.Text.RegularExpressions;

namespace BLL.Validators
{
    public class UserValidator : AbstractValidator<RegisterRequest>
    {
        public UserValidator()
        {
            RuleFor(u => u.Phone).NotEmpty()
                .Length(13)
                .Matches(new Regex(@"^\+375(17|29|33|44)[0-9]{7}$"));
        }
    }
}
