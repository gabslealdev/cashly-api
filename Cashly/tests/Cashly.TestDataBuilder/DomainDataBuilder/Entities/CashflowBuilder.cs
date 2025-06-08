using Bogus;
using Cashly.Domain.Entities;

namespace Cashly.TestDataBuilder.DomainDataBuilder.Entities;
public static class CashflowBuilder
{
    public static Cashflow BuildValidCashflow()
    {
        var faker = new Faker("pt_BR");

        return new Cashflow(
            id: faker.Random.Int(1, 1000),
            user: UserBuilder.BuildValidUser()
            );
    }


}
