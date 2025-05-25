using Cashly.Communication.Requests.RequestRegisterCategoryJson;
using FluentValidation;

namespace Cashly.Application.UseCases.Categories.Register
{
    public class RegisterCategoryValidator : AbstractValidator<RegisterCategoryRequest>
    {
        public RegisterCategoryValidator()
        {
            RuleFor(category => category.Name).NotEmpty().WithMessage("Name is required");
        }
    }
}
