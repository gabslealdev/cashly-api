using Bogus;
using Cashly.Domain.ValueObjects;

namespace Cashly.TestFixtures.Fixtures.ValueObjects
{
    public static class NameFixture
    {
        private static string Empty() => string.Empty;
        private static string Null() => null;
        private static string WhiteSpace() => "     ";

        public static Name CreateValidName()
        {
            var faker = new Faker("pt_BR");

            return new Name(faker.Name.FirstName());
        }

        public static Name CreateInvalidNameWithShortLength()
        {
            var faker = new Faker("pt_BR");

            return new Name(faker.Random.String2(1, 2));
        }

        public static Name CreateInvalidNameWithNullOrWhiteSpaceValue()
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
}
