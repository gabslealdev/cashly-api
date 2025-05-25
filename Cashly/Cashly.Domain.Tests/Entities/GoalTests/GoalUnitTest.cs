using Bogus;
using Cashly.Domain.Entities;
using Cashly.Domain.Exceptions;
using Cashly.Domain.ValueObjects;
using Cashly.TestFixtures.Fixtures.Entities;
using Shouldly;

namespace Cashly.Domain.Tests.Entities.GoalTests
{
    public class GoalUnitTest
    {
        [Fact(DisplayName = "Create Goal with valid parameters result object valid state")]
        public void CreateGoal_WithValidParameters_ResultObjectValidState()
        {
            // ACT
            Action action = () => GoalFixture.CreateValidGoal();

            // ASSERT
            action.ShouldNotThrow();
        }

        [Fact(DisplayName = "Create Goal seting Dealine result object valid state")]
        public void CreateGoal_SetingDeadline_ResultObjectValidState()
        {
            // ARRANGE
            var faker = new Faker();
            var goal = GoalFixture.CreateValidGoal();

            // ACT
            Action action = () => goal.SetDeadline(
                faker.Date.Future(refDate: (DateTime)goal.Deadline, yearsToGoForward: 1));

            // ASSERT
            action.ShouldNotThrow();
        }

        [Fact(DisplayName = "Create Goal with invalid set Dealine result DomainExceptionValidation")]
        public void CreateGoal_WithInvalidSetDeadline_ResultDomainExceptionValidation()
        {
            // ARRANGE
            var faker = new Faker();
            var goal = GoalFixture.CreateValidGoal();

            // ACT
            Action action = () => goal.SetDeadline(faker.Date.Soon());

            // ASSERT
            action.ShouldThrow<DomainExceptionValidation>().Message.ShouldBe("The new deadline cannot be earlier than the current deadline");


        }
    }
}
