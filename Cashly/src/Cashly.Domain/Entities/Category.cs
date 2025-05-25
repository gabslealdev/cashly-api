using Cashly.Domain.Entities.bases;
using Cashly.Domain.Exceptions;
using Cashly.Domain.ValueObjects;

namespace Cashly.Domain.Entities
{
    public sealed class Category(int id, Name name, string description) : Entity(id)
    {
        public Name Name { get; private set; } = name;
        public string? Description { get; private set; } = description;
        public ICollection<Transaction> Transactions { get; private set; } = [];
        public void AddTransaction(Transaction transaction)
        {
            if (transaction is null)
                throw new DomainExceptionValidation("Transaction cannot be null");

            if(!transaction.Category.Name.Equals(Name))
                throw new DomainExceptionValidation("The transaction does not belong to this category");

            Transactions.Add(transaction);
        }

    }
}
