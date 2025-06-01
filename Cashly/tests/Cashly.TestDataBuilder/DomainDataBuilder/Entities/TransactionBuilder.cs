using Bogus;
using Cashly.Domain.Entities;
using Cashly.Domain.Enums;
using Cashly.Domain.ValueObjects;

namespace Cashly.TestDataBuilder.DomainDataBuilder.Entities;
public static class TransactionBuilder
{
    public static Transaction BuildValidTransaction()
    {
        var faker = new Faker();

        return new Transaction(
            id: faker.Random.Int(1, 1000),
            amount: new Cash(faker.Random.Decimal(0.9m, 4999.99m)),
            date: faker.Date.Soon(),
            description: faker.Commerce.ProductDescription(),
            type: faker.PickRandom<TransactionType>(),
            category: CategoryBuilder.BuildValidCategory(),
            cashflow: CashflowBuilder.BuildValidCashflow()
            );
    }

    public static Transaction BuildValidExpenseTransaction()
    {
        var faker = new Faker();

        return new Transaction(
            id: faker.Random.Int(1, 1000),
            amount: new Cash(faker.Random.Decimal(0.9m, 4999.99m)),
            date: faker.Date.Soon(),
            description: faker.Commerce.ProductDescription(),
            type: TransactionType.Expense,
            category: CategoryBuilder.BuildValidCategory(),
            cashflow: CashflowBuilder.BuildValidCashflow()
            );
    }

    public static Transaction BuildValidIncomeTransaction()
    {
        var faker = new Faker();

        return new Transaction(
            id: faker.Random.Int(1, 1000),
            amount: new Cash(faker.Random.Decimal(0.9m, 4999.99m)),
            date: faker.Date.Soon(),
            description: faker.Commerce.ProductDescription(),
            type: TransactionType.Income,
            category: CategoryBuilder.BuildValidCategory(),
            cashflow: CashflowBuilder.BuildValidCashflow()
            );
    }
}
