using Cashly.Domain.Entities.bases;
using Cashly.Domain.Enums;
using Cashly.Domain.Exceptions;
using Cashly.Domain.ValueObjects;

namespace Cashly.Domain.Entities
{
    public sealed class Transaction(int id, Cash amount, DateTime date, string description, TransactionType type, Category category, Cashflow cashflow) : Entity(id)
    {
        public Cash Amount { get; private set; } = amount;
        public DateTime Date { get; private set; } = date;
        public string? Description { get; private set; } = description;
        public TransactionType Type { get; private set; } = type;
        public TransactionStatus Status { get; private set; } = TransactionStatus.Scheduled;
        public int CategoryId { get; set; } = category.Id;
        public Category Category { get; } = ValidateCategory(category);
        public int CashflowId { get; set; } = cashflow.Id;
        public Cashflow Cashflow { get; } = ValidateCashflow(cashflow);

        public void MarkAsCompleted()
        {
            if (Status == TransactionStatus.Canceled)
                throw new DomainExceptionValidation("Cannot complete a canceled transaction");

            Status = TransactionStatus.Completed;
        }
        public void MarkAsCanceled() 
        {
            if (Status == TransactionStatus.Completed)
                throw new DomainExceptionValidation("Cannot cancel a completed transaction.");

            Status = TransactionStatus.Canceled;
        }
        private static Category ValidateCategory(Category category) => category ?? throw new ArgumentNullException("Category cannot be null");
        private static Cashflow ValidateCashflow(Cashflow cashflow) => cashflow ?? throw new ArgumentNullException("Cashflow cannot be null");

    }
}
