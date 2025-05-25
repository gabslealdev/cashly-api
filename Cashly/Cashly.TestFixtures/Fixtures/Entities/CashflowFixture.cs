using Bogus;
using Cashly.Domain.Entities;

namespace Cashly.TestFixtures.Fixtures.Entities
{
    public static class CashflowFixture
    {
        public static Cashflow CashflowValid()
        {
            var faker = new Faker("pt_BR");

            return new Cashflow(
                id: faker.Random.Int(1, 1000),
                user: UserFixture.CreateValidUser()
                );
        }


    }
}
