using Bogus;
using Cashly.Domain.ValueObjects;

namespace Cashly.TestDataBuilder.DomainDataBuilder.ValueObjects;
public static class NameBuilder
{
    private static string Empty() => string.Empty;
    private static string Null() => null;
    private static string WhiteSpace() => "     ";
    public static Name BuildValidName()
    {
        var faker = new Faker("pt_BR");

        return new Name(faker.Name.FirstName());
    }
    public static Name BuildInvalidNameWithShortLength()
    {
        var faker = new Faker("pt_BR");

        return new Name(faker.Random.String2(1, 2));
    }
    public static Name BuildInvalidNameWithNullOrWhiteSpaceValue()
    {
        var faker = new Faker();

        var options = new List<string?>
        {
            Empty(),
            Null(),
            WhiteSpace(),
        };

        return new Name(faker.PickRandom(options));
    }
}
