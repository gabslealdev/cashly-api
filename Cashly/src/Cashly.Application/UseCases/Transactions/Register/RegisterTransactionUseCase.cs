using Cashly.Communication.Requests.Transaction;
using Cashly.Communication.Responses.Transaction;
using Cashly.Exception.ExceptionBase;

namespace Cashly.Application.UseCases.Transactions.Register
{
    public class RegisterTransactionUseCase
    {
        public RegisteredTransactionResponse Execute(RegisterTransactionRequest request)
        {
            Validate(request);

            return new RegisteredTransactionResponse();
        }

        private void Validate(RegisterTransactionRequest request)
        {
            var validator = new RegisterTransactionValidator();
            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
