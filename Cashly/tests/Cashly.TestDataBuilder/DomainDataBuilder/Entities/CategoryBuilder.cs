using Bogus;
using Cashly.Domain.Entities;
using Cashly.Domain.ValueObjects;

namespace Cashly.TestDataBuilder.DomainDataBuilder.Entities;
public static class CategoryBuilder
{
    public static Category BuildValidCategory()
    {
        var faker = new Faker("pt_BR");

        return new Category(
            id: faker.Random.Int(1, 1000),
            name: new Name(faker.Commerce.Categories(1)[0]),
            description: faker.Lorem.Sentence()
            );
    }

    public static Category BuildInvalidCategory()
    {
        var faker = new Faker("pt_BR");

        return new Category(
            id: faker.Random.Int(-1000, 0),
            name: new Name(faker.Commerce.Categories(1)[0]),
            description: faker.Lorem.Sentence()
            );
    }
}
