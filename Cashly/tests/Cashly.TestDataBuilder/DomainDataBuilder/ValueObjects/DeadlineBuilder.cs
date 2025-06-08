using Bogus;
using Cashly.Domain.ValueObjects;

namespace Cashly.TestFixtures.Fixtures.ValueObjects
{
    public static class DeadlineGoalFixture
    {
        public static DeadlineGoal CreateValidDeadlineGoal()
        {
            var faker = new Faker();

            return new DeadlineGoal(
                faker.Date.FutureOffset().AddDays(30)
                );
        }
        public static DeadlineGoal CreateInvalidDeadlineGoal()
        {
            var faker = new Faker();

            return new DeadlineGoal(
                faker.Date.BetweenOffset(DateTimeOffset.Now.Date, DateTimeOffset.Now.Date.AddDays(30))
                );
        }

    }
}
