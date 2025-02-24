namespace Cashly.Domain.Entities
{
    public class Wish
    {
        public int Id { get; private set; }
        public decimal  Amount { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get;  private set; }

        public Wish(int id, decimal amount, DateTime startDate, DateTime endDate, User user)
        {
            Id = id;
            Amount = amount;
            StartDate = startDate;
            EndDate = endDate;
            User = user;
            UserId = user.Id;
        }

        public int UserId { get; private set; }
        public  User User { get; private set; }

    }
}
