using Cashly.Domain.Exceptions;
using Cashly.Domain.ValueObjects;

namespace Cashly.Domain.Entities
{
    public sealed class Category
    {
        public int Id { get; private set; }
        public CategoryName Name { get; private set; }

        public Category(CategoryName name)
        {
            Name = name;
        }

        public Category(int id, CategoryName name)
        {
            ValidateId(id);
            Name = name;
        }


        public ICollection<Transaction> Transactions { get; private set; } = [];

        public void AddTransaction(Transaction transaction)
        {
            Transactions.Add(transaction);
        }
        public void Update(CategoryName name)
        {
            Name = name;
        }

        private void ValidateId(int id)
        {
            DomainExceptionValidation.When(id < 0, "Error: Invalid value");
            Id = id;
        }


    }
}
