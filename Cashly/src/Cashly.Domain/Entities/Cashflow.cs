using Cashly.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cashly.Domain.Entities
{
    public class Cashflow
    {
        public int Id { get; set; }
        public decimal CurrentBalance { get; set; }
        public CashflowStatus Status { get; set; }
        public DateTime LastUpdated { get; set; }


        public User User { get; set; }
        public int UseId { get; set; }
        public ICollection<Transaction> Transactions { get; set; } = [];
    }
}
