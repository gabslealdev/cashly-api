using Bogus;
using Cashly.Domain.ValueObjects;

namespace Cashly.TestFixtures.Fixtures.ValueObjects
{
    public static class EmailFixture
    { 
        public static Email CreateValidEmail()
        {
            var faker = new Faker();

            return new Email(faker.Internet.Email());
        }

        public static Email CreateInvalidEmail()
        {
            var faker = new Faker();

            return new Email(faker.Random.String());
        }
    }
}
