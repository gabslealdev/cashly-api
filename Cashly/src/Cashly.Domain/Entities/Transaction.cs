using Cashly.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cashly.Domain.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; } = string.Empty;
        public TransactionType Type { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }

    }
}
