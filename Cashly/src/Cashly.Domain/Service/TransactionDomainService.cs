using Cashly.Domain.Entities;
using Cashly.Domain.Enums;
using Cashly.Domain.Exceptions;

namespace Cashly.Domain.Service
{
    public class TransactionDomainService
    {
        public void CancelTransaction(Transaction transaction, Cashflow cashflow)
        {
            if (transaction.Status == TransactionStatus.Completed)
                throw new DomainExceptionValidation("Cannot cancel a completed transaction");

            if (transaction.Status == TransactionStatus.Scheduled)
            {
                if (transaction.Type == TransactionType.Expense)
                    cashflow.RevertExpense(transaction.Amount);
                else
                    cashflow.RevertIncome(transaction.Amount);
            }

            transaction.MarkAsCanceled();
        }
    }
}
