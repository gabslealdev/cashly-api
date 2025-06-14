﻿using Cashly.Communication.Requests.Transaction.Enum;

namespace Cashly.Communication.Responses.Transaction
{
    public class RegisteredTransactionResponse
    {
        public decimal Amount { get; set; }
        public DateTimeOffset Date { get; set; }
        public string Description { get; set; } = string.Empty;
        public TransactionTypeRequest Type { get; set; }
        public string Category { get; set; } = string.Empty;
    }
}
