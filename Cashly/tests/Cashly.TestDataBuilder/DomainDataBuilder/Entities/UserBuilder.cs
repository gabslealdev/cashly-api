using Bogus;
using Cashly.Domain.Entities;
using Cashly.Domain.ValueObjects;

namespace Cashly.TestDataBuilder.DomainDataBuilder.Entities;
public static class UserBuilder
{
    public static User BuildValidUser()
    {
        var faker = new Faker("pt_BR");

        return new User(
           id: faker.Random.Int(1, 1000),
           name: new Name(faker.Name.FirstName()),
           email: new Email(faker.Internet.Email()),
           passwordHash: faker.Random.Hash()
         );
    }
}
