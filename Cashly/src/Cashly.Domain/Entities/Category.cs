

namespace Cashly.Domain.Entities
{
    public sealed class Category
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;

        public Category(string name)
        {
            Name = name;
        }

        public Category(int id, string name)
        {
            Id = id;
            Name = name;
        }


        public ICollection<Transaction> Transactions { get; private set; } = [];

        public void AddTransaction(Transaction transaction)
        {
            Transactions.Add(transaction);
        }
        

    }
}
