using Cashly.Communication.Requests.Transaction;
using FluentValidation;

namespace Cashly.Application.UseCases.Transactions.Register
{
    public class RegisterTransactionValidator: AbstractValidator<RegisterTransactionRequest>
    {
        public RegisterTransactionValidator()
        {

            RuleFor(transaction => transaction.Amount).GreaterThan(0).WithMessage("Invalid Amount. Amount must be greater than 0");
            RuleFor(transaction => transaction.Date).NotEmpty().WithMessage("Invalid Date. Date is required");
            RuleFor(transaction => transaction.Type).IsInEnum().WithMessage("Invalid Type, Type is not registered");
            RuleFor(transaction => transaction)
                .Custom((transaction, context) => 
                {
                    if (transaction.CreatedCategoryId is null && string.IsNullOrWhiteSpace(transaction.NewCategoryName))
                        context.AddFailure("Category", "A category is required. Please select an existing one or provide a new name.");
                });
        }
    }
}
