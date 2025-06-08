using Bogus;
using Cashly.Domain.Entities;
using Cashly.Domain.ValueObjects;

namespace Cashly.TestDataBuilder.DomainDataBuilder.Entities;
public static class GoalBuilder
{
    public static Goal BuildValidGoal()
    {
        var faker = new Faker();

        return new Goal(
            id: faker.Random.Int(1, 1000),
            value: new Cash(faker.Random.Decimal(999.99m, 4999.99m)),
            deadline: new DeadlineGoal(faker.Date.BetweenOffset(DateTimeOffset.Now.Date, DateTimeOffset.Now.Date.AddYears(3))),
            cashflow: CashflowBuilder.BuildValidCashflow()
            );
    }
}
