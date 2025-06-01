using Cashly.Communication.Requests.User;
using FluentValidation;

namespace Cashly.Application.UseCases.Users.Register
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserRequest>
    {
        public RegisterUserValidator()
        {
            RuleFor(user => user.Name)
                .NotEmpty().WithMessage("Invalid name. Name is required")
                .MinimumLength(3).WithMessage("Invalid name. Minimun 3 characters");

            RuleFor(user => user.Email)
                .EmailAddress().WithMessage("Invalid email. Please use the format: name@example.com");

            RuleFor(x => x.Password)
                       .NotEmpty().WithMessage("Password is required.")
                       .MinimumLength(8).WithMessage("Password must be at least 8 characters.")
                       .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                       .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
                       .Matches("[0-9]").WithMessage("Password must contain at least one number.")
                       .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character.");
        }
    }
}
