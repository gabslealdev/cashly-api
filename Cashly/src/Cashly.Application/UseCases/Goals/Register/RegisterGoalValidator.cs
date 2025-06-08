using Cashly.Communication.Requests.Goal;
using FluentValidation;

namespace Cashly.Application.UseCases.Goals.Register
{
    public class RegisterGoalValidator : AbstractValidator<RegisterGoalRequest>
    {
        public RegisterGoalValidator()
        {
            RuleFor(goal => goal.Value).GreaterThanOrEqualTo(1).WithMessage("Invalid value. Value must be greater or equal to 1.00");

            RuleFor(goal => goal.Deadline).GreaterThan(DateTimeOffset.Now.Date.AddDays(30)).WithMessage("Invalid deadline. Deadline must be at least 30 days after from today");
        }
    }
}
