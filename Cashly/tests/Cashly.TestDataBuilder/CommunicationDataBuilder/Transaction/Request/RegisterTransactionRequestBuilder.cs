using Bogus;
using Cashly.Communication.Requests.Transaction;
using Cashly.Communication.Requests.Transaction.Enum;

namespace Cashly.TestDataBuilder.CommunicationDataBuilder.Transaction.Request
{
    public class RegisterTransactionRequestBuilder
    {
        public static RegisterTransactionRequest Build()
        {
            var faker = new Faker();

            return new RegisterTransactionRequest
            {
                Amount = faker.Random.Decimal(1, 2000),
                Date = faker.Date.SoonOffset(),
                Description = faker.Commerce.ProductDescription(),
                Type = faker.PickRandom<TransactionTypeRequest>(),
                CreatedCategoryId = faker.Random.Int(),
                NewCategoryName = faker.Commerce.ProductName(),
                NewCategoryDescription = faker.Commerce.ProductDescription(),
            };
        }
    }
}
