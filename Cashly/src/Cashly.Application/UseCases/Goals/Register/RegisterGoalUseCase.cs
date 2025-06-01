using Cashly.Application.UseCases.Goals.Register;
using Cashly.Communication.Requests.Goal;
using Cashly.Communication.Responses.Goal;
using Cashly.Exception.ExceptionBase;

namespace Cashly.Application.UseCases.Goals
{
    public class RegisterGoalUseCase
    {
        public RegisteredGoalResponse Execute(RegisterGoalRequest request)
        {
            Validate(request); 

            return new RegisteredGoalResponse();
        }

        private void Validate(RegisterGoalRequest request)
        {
            var validator = new RegisterGoalValidator();

            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
