using Bogus;
using Cashly.Domain.Entities;
using Cashly.Domain.Enums;
using Cashly.Domain.ValueObjects;

namespace Cashly.TestFixtures.Fixtures.Entities
{
    public static class TransactionFixture
    {
        public static Transaction TransactionValid()
        {
            var faker = new Faker();

            return new Transaction(
                id: faker.Random.Int(1, 1000),
                amount: new Cash(faker.Random.Decimal(0.9m, 4999.99m)),
                date: faker.Date.Soon(),
                description: faker.Commerce.ProductDescription(),
                type: faker.PickRandom<TransactionType>(),
                category: CategoryFixture.CreateValidCategory(),
                cashflow: CashflowFixture.CashflowValid()
                );
        }

        public static Transaction ExpenseTransactionValid()
        {
            var faker = new Faker();

            return new Transaction(
                id: faker.Random.Int(1, 1000),
                amount: new Cash(faker.Random.Decimal(0.9m, 4999.99m)),
                date: faker.Date.Soon(),
                description: faker.Commerce.ProductDescription(),
                type: TransactionType.Expense,
                category: CategoryFixture.CreateValidCategory(),
                cashflow: CashflowFixture.CashflowValid()
                );
        }

        public static Transaction IncomeTransactionValid()
        {
            var faker = new Faker();

            return new Transaction(
                id: faker.Random.Int(1, 1000),
                amount: new Cash(faker.Random.Decimal(0.9m, 4999.99m)),
                date: faker.Date.Soon(),
                description: faker.Commerce.ProductDescription(),
                type: TransactionType.Income,
                category: CategoryFixture.CreateValidCategory(),
                cashflow: CashflowFixture.CashflowValid()
                );
        }
    }
}
