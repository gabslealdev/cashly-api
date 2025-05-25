using Cashly.Domain.Entities.bases;
using Cashly.Domain.Enums;
using Cashly.Domain.Exceptions;
using Cashly.Domain.ValueObjects;

namespace Cashly.Domain.Entities
{
    public sealed class Cashflow(int id, User user) : Entity(id)
    {
        public decimal CurrentBalance { get; private set; } = 0;
        public CashflowStatus Status { get; private set; } = CashflowStatus.yellow;
        public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;
        public User User { get; } = ValidateUser(user); 
        public int UserId { get; set; } = user.Id;
        public Goal? Goal { get; set; }
        public int? GoalId { get; set; }
        public ICollection<Transaction> Transactions { get; private set; } = [];

        public void AddTransaction(Transaction transaction)
        {
            if (transaction is null)
                throw new ArgumentNullException(nameof(transaction));

            if (transaction.Type is TransactionType.Expense)
                AddExpense(transaction.Amount);
            else
                AddIncome(transaction.Amount);

            UpdatedAt = DateTime.UtcNow;
            SetCashflowStatus();
            Transactions.Add(transaction);
        }
        public void RemoveTransaction(Transaction transaction) 
        {
            if (!Transactions.Contains(transaction))
                throw new ArgumentException(nameof(transaction));

            if (transaction.Type is TransactionType.Expense)
                CurrentBalance += (decimal)transaction.Amount;
            else
               CurrentBalance -= (decimal)transaction.Amount;

            Transactions.Remove(transaction);
            UpdatedAt = DateTime.UtcNow;
            SetCashflowStatus();
        }
        public void SetCashflowStatus()
        {
            if (CurrentBalance < 0)
                Status = CashflowStatus.red;

            if (CurrentBalance == 0)
                Status = CashflowStatus.yellow;

            if (CurrentBalance > 0)
                Status = CashflowStatus.green;
        }
        private void AddIncome(Cash income)
        {
            CurrentBalance += (decimal)income;
        }
        private void AddExpense(Cash expense)
        {
            CurrentBalance -= (decimal)expense;
        }
        public void RevertExpense(Cash expense)
        {
            CurrentBalance += (decimal)expense;
            UpdatedAt = DateTime.UtcNow;
            SetCashflowStatus();
        }
        public void RevertIncome(Cash income)
        {
            CurrentBalance -= (decimal)income;
            UpdatedAt = DateTime.UtcNow;
            SetCashflowStatus();
        }
        private static User ValidateUser(User user) => user ?? throw new ArgumentNullException("User cannot be null");
    }
}
