using Cashly.Communication.Requests.Transaction.Enum;

namespace Cashly.Communication.Requests.Transaction
{
    public class RegisterTransactionRequest
    {
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; } = string.Empty;
        public TransactionTypeRequest Type { get; set; }
        public int? CreatedCategoryId { get; set; }
        public string? NewCategoryName { get; set; } = string.Empty;
        public string? NewCategoryDescription { get; set; } = string.Empty;
    }
}
