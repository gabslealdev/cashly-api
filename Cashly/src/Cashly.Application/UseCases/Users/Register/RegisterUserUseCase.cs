using Cashly.Communication.Requests.User;
using Cashly.Communication.Responses.User;
using Cashly.Exception.ExceptionBase;

namespace Cashly.Application.UseCases.Users.Register
{
    public class RegisterUserUseCase
    {
        public RegisteredUserResponse Execute(RegisterUserRequest request)
        {
            Validate(request);

            // Atenção: Converter tipos primitivos em VOs nesse ponto. 
            // Atenção: Converter VOs em tipos primitivos antes retornar um RegisteredUserResponse, isso mantém o dominio isolado e API externa interoperavel.
            // Atenção: Criar o Cashflow aqui.

            return new RegisteredUserResponse();
        }

        private void Validate(RegisterUserRequest request)
        {
            var validator = new RegisterUserValidator();
            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
