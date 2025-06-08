using Cashly.Domain.Entities.bases;
using Cashly.Domain.Enums;
using Cashly.Domain.Exceptions;
using Cashly.Domain.ValueObjects;

namespace Cashly.Domain.Entities
{
    public sealed class Transaction : Entity
    {
        public Cash Amount { get; private set; }
        public DateTimeOffset Date { get; private set; }
        public string? Description { get; private set; }
        public TransactionType Type { get; private set; }
        public TransactionStatus Status { get; private set; } = TransactionStatus.scheduled;
        public Category Category { get; }
        public int CategoryId { get; set; }
        public Cashflow Cashflow { get; }
        public int CashflowId { get; set; }

        public Transaction(int id, Cash amount, DateTimeOffset date, string description, TransactionType type, Category category, Cashflow cashflow)  : base(id)
        {
            Amount = amount;
            Date = date;
            Description = description;
            Type = type;
            Category = ValidateCategory(category);
            Cashflow = ValidateCashflow(cashflow);
        }

        private Transaction(){ }

        public void MarkAsCompleted()
        {
            if (Status == TransactionStatus.canceled)
                throw new DomainExceptionValidation("Cannot complete a canceled transaction");

            Status = TransactionStatus.completed;
        }
        public void MarkAsCanceled() 
        {
            if (Status == TransactionStatus.completed)
                throw new DomainExceptionValidation("Cannot cancel a completed transaction.");

            Status = TransactionStatus.canceled;
        }
        private static Category ValidateCategory(Category category) => category ?? throw new DomainExceptionValidation("Category cannot be null");
        private static Cashflow ValidateCashflow(Cashflow cashflow) => cashflow ?? throw new DomainExceptionValidation("Cashflow cannot be null");

    }
}
