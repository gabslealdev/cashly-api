using Bogus;
using Cashly.Domain.ValueObjects;

namespace Cashly.TestDataBuilder.DomainDataBuilder.ValueObjects;
public static class CashBuilder
{
    public static Cash BuildValidCash()
    {
        var faker = new Faker();

        return new Cash(
            faker.Random.Decimal()
            );
    }

    public static Cash BuildInvalidCash()
    {
        var faker = new Faker();
        var value = faker.Random.Decimal(1.00m, 1000.00m);
        value = -value;

        return new Cash(value);
    }
}
