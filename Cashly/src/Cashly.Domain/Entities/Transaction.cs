using Cashly.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cashly.Domain.Entities
{
    public sealed class Transaction
    {
        public int Id { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime Date { get; private set; }
        public string? Description { get; private set; } = string.Empty;
        public TransactionType Type { get; private set; }

        public Transaction(int id, decimal amount, DateTime date, string description, TransactionType type, User user, Category category, Cashflow cashflow )
        {
            Id = id;
            Amount = amount;
            Date = date;
            Description = description;
            Type = type;
            User = user;
            UserId = user.Id;
            Category = category;
            CategoryId = category.Id;
            Cashflow = cashflow;
            CashflowId = cashflow.Id;

        }

        public int UserId { get; set; }
        public User User { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int CashflowId { get; set; }
        public Cashflow Cashflow { get; set; }

    }
}
