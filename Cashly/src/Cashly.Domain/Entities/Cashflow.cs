using Cashly.Domain.Entities.bases;
using Cashly.Domain.Enums;

namespace Cashly.Domain.Entities
{
    public sealed class Cashflow(decimal currentBalance, CashflowStatus status, User user) : Entity
    {
        public decimal CurrentBalance { get; set; } = currentBalance;
        public CashflowStatus Status { get; set; } = status;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public required User User { get; set; } = user;
        public int UseId { get; set; } = user.Id;
        public ICollection<Transaction> Transactions { get; set; } = [];

        public void AddTransaction(Transaction transaction)
        {
            Transactions.Add(transaction);
            UpdatedAt = DateTime.UtcNow;
        }

    }
}
