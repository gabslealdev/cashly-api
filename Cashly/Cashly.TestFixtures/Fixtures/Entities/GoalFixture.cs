using Bogus;
using Cashly.Domain.Entities;
using Cashly.Domain.ValueObjects;

namespace Cashly.TestFixtures.Fixtures.Entities
{
    public static class GoalFixture
    {
        public static Goal CreateValidGoal()
        {
            var faker = new Faker();

            return new Goal(
                id: faker.Random.Int(1, 1000),
                value: new Cash(faker.Random.Decimal(999.99m, 4999.99m)),
                deadline: new DeadlineGoal(faker.Date.Between(DateTime.Now, new DateTime(2026, 12, 25))),
                cashflow: CashflowFixture.CashflowValid()
                );
        }
    }
}
