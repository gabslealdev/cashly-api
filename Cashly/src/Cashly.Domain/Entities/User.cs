using System.Globalization;

namespace Cashly.Domain.Entities
{
    public sealed class User
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string Password { get; private set; } = string.Empty;
        public DateTime RegisterDate { get; private set; }

        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
            DateTime RegisterDate = DateTime.Now;
        }

        public User(int id, string name, string email, string password)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            DateTime RegisterDate = DateTime.Now;
        }

        public ICollection<Transaction> Transactions { get; private set; } = [];
        public ICollection<Wish> Wishes { get; private set; } = [];

        public void AddTransaction(Transaction transaction)
        {
            Transactions.Add(transaction);
        }

        public void AddWish(Wish wish)
        {
            Wishes.Add(wish);
        }

    }
}
