using Cashly.Domain.Entities.bases;
using Cashly.Domain.Enums;
using Cashly.Domain.ValueObjects;

namespace Cashly.Domain.Entities
{
    public sealed class Transaction(Cash amount, DateTime date, string description, TransactionType type, User user, Category category, Cashflow cashflow ) : Entity
    {
        public Cash Amount { get; private set; } = amount;
        public DateTime Date { get; private set; } = date;
        public string? Description { get; private set; } = description;
        public TransactionType Type { get; private set; } = type;
        public int CategoryId { get; set; } = category.Id;
        public Category Category { get; set; } = category;
        public int CashflowId { get; set; } = cashflow.Id;
        public Cashflow Cashflow { get; set; } = cashflow;

    }
}
