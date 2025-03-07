namespace Cashly.Domain.Entities
{
    public sealed class Goal
    {
        public int Id { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime Deadline { get;  private set; }

        public Goal(int id, decimal amount, DateTime deadline, User user)
        {
            Id = id;
            Amount = amount;
            Deadline = deadline;
            User = user;
            UserId = user.Id;
        }

        public int UserId { get; set; }
        public  User User { get; set; }

    }
}
