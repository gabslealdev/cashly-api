using Bogus;
using Cashly.Domain.ValueObjects;

namespace Cashly.TestDataBuilder.DomainDataBuilder.ValueObjects;
public static class EmailBuilder
{ 
    public static Email BuildValidEmail()
    {
        var faker = new Faker();

        return new Email(faker.Internet.Email());
    }

    public static Email BuildInvalidEmail()
    {
        var faker = new Faker();

        return new Email(faker.Random.String());
    }
}
