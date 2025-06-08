using Cashly.Domain.Entities.bases;
using Cashly.Domain.Enums;
using Cashly.Domain.Exceptions;
using Cashly.Domain.ValueObjects;

namespace Cashly.Domain.Entities
{
    public sealed class Cashflow : Entity
    {

        public decimal CurrentBalance { get; private set; } = 0.0m;
        public CashflowStatus Status { get; private set; } = CashflowStatus.yellow;
        public DateTimeOffset UpdatedAt { get; private set; } = DateTimeOffset.UtcNow;
        public User User { get; private set; } = default!;
        public int UserId { get; set; }
        public Goal? Goal { get; set; }
        public ICollection<Transaction> Transactions { get; private set; } = [];

        public Cashflow(int id, User user) : base(id)
        {
            User = user;
        }
        private Cashflow()
        {
            
        }

        public void AddTransaction(Transaction transaction)
        {
            if (transaction is null)
                throw new DomainExceptionValidation(nameof(transaction));

            if (transaction.Type is TransactionType.expense)
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
                throw new DomainExceptionValidation(nameof(transaction));

            if (transaction.Type is TransactionType.expense)
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

            else if (CurrentBalance == 0)
                Status = CashflowStatus.yellow;

            else 
                Status = CashflowStatus.green;
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
        private void AddIncome(Cash income)
        {
            CurrentBalance += (decimal)income;
        }
        private void AddExpense(Cash expense)
        {
            CurrentBalance -= (decimal)expense;
        }

    }
}
