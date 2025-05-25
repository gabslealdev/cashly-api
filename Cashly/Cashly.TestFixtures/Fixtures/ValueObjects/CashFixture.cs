using Bogus;
using Cashly.Domain.ValueObjects;

namespace Cashly.TestFixtures.Fixtures.ValueObjects
{
    public static class CashFixture
    {
        public static Cash CreateValidCash()
        {
            var faker = new Faker();

            return new Cash(
                faker.Random.Decimal()
                );
        }

        public static Cash CreateInvalidCash()
        {
            var faker = new Faker();
            var value = faker.Random.Decimal(1.00m, 1000.00m);
            value = -value;

            return new Cash(value);
        }
    }
}
