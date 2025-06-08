using Cashly.Domain.Entities.bases;
using Cashly.Domain.Exceptions;
using Cashly.Domain.ValueObjects;

namespace Cashly.Domain.Entities
{
    public sealed class Category : Entity
    {
        public Name Name { get; private set; }
        public string? Description { get; private set; }
        public ICollection<Transaction> Transactions { get; private set; } = [];
      
        public Category(int id, Name name, string description) : base(id)
        {
            Name = name;
            ValidateDescription(description);
            Description = description;
        }
        private Category()
        {
            
        }

        public void AddTransaction(Transaction transaction)
        {
            if (transaction is null)
                throw new DomainExceptionValidation("Transaction cannot be null");

            if (transaction.Category != this)
                throw new DomainExceptionValidation("The transaction does not belong to this category");

            Transactions.Add(transaction);
        }
        private void ValidateDescription(string description)
        {
            DomainExceptionValidation.When(description.Length > 100, "Description too long");
        }
    }
}
