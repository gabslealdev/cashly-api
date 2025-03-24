using Cashly.Domain.Entities.bases;
using Cashly.Domain.ValueObjects;

namespace Cashly.Domain.Entities
{
    public sealed class Category(Name name) : Entity
    {
        public Name Name { get; private set; } = name;

        public ICollection<Transaction> Transactions { get; private set; } = [];

        public void AddTransaction(Transaction transaction)
        {
            if(transaction.Category.Name == Name) 
                Transactions.Add(transaction);
        }
        public void Update(Name name)
        {
            Name = name; 
        }

    }
}
