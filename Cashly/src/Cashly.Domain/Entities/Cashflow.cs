using Cashly.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cashly.Domain.Entities
{
    public sealed class Cashflow
    {
        public int Id { get; set; }
        public decimal CurrentBalance { get; set; }
        public CashflowStatus Status { get; set; }
        public DateTime LastUpdated { get; set; }

        public Cashflow(int id, decimal currentBalance, CashflowStatus status, DateTime lastUpdated, User user)
        {
            Id = id;
            CurrentBalance = currentBalance;
            Status = status;
            LastUpdated = lastUpdated;
            User = user;
            UseId = user.Id;
        }

        public User User { get; set; }
        public int UseId { get; set; }
        public ICollection<Transaction> Transactions { get; set; } = [];

    }
}
