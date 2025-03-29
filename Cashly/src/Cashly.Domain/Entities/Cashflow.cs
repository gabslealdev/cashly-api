using Cashly.Domain.Entities.bases;
using Cashly.Domain.Enums;

namespace Cashly.Domain.Entities
{
    public sealed class Cashflow( CashflowStatus status, User user, Goal goal ) : Entity
    {
        public decimal CurrentBalance { get; private set; } = 0;
        public CashflowStatus Status { get; private set; } = status;
        public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;
        public User User { get; set; } = user;
        public int UseId { get; set; } = user.Id;
        public Goal Goal { get; set; } = goal;
        public int GoalId { get; set; } = goal.Id;
        public ICollection<Transaction> Transactions { get; set; } = [];

        public void AddTransaction(Transaction transaction)
        {
            Transactions.Add(transaction);
            UpdatedAt = DateTime.UtcNow;
        }
        public void RemoveTransaction(Transaction transaction)
        {
            Transactions.Remove(transaction);
            UpdatedAt = DateTime.UtcNow;
        }  
        public void SetCashflowStatus()
        {
            if(CurrentBalance < 0)
                Status = CashflowStatus.red;

            if(CurrentBalance == 0)
                Status = CashflowStatus.yellow;

            if(CurrentBalance > 0)
                Status = CashflowStatus.green;
        }

    }
}
