using Cashly.Communication.Requests.RequestRegisterCategoryJson;
using Cashly.Communication.Responses.ResponseRegistredCategoryJson;
using Cashly.Exception.ExceptionBase;

namespace Cashly.Application.UseCases.Categories.Register;

public class RegisterCategoryUseCase
{
    public RegisteredCategoryResponse Execute(RegisterCategoryRequest request)
    {
        Validate(request);

        return new RegisteredCategoryResponse();
    }

    private void Validate(RegisterCategoryRequest request)
    {
        var validator = new RegisterCategoryValidator();

        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
