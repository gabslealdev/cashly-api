using Bogus;
using Cashly.Domain.Exceptions;
using Cashly.Domain.ValueObjects;
using Cashly.TestFixtures.Fixtures.ValueObjects;
using Shouldly;

namespace Cashly.Domain.Tests.ValueObjects
{
    public class ValueObjectDeadlineGoalUnitTests
    {
        [Fact(DisplayName = "Create a deadlineGoal with valid parameters result value object")]
        public void CreateDeadlineGoal_WithValidParameters_ResultValueObject()
        {
            // ACT
            Action action = () => DeadlineGoalFixture.CreateValidDeadlineGoal();

            // ASSERT
            action.ShouldNotThrow();
        }

        [Fact(DisplayName = "Create a deadlineGoal with invalid parameters result DomainExceptionValidation")]
        public void CreateDeadlineGoal_WithInvalidParameters_ResultDomainExceptionValidation()
        {
            // ACT
            Action action = () => DeadlineGoalFixture.CreateInvalidDeadlineGoal();

            // ASSERT
            action.ShouldThrow<DomainExceptionValidation>().Message.ShouldBe("Deadline must be at least 30 days after from now");
        }

        [Fact(DisplayName = "Equals with same values result should be true")]
        public void Equals_WithSameValues_ResultShouldBeTrue()
        {
            // ARRANGE
            var faker = new Faker();
            var date = faker.Date.Future().AddDays(60);
            var deadlineGoalA = new DeadlineGoal(date);
            var deadlineGoalB = new DeadlineGoal(date);

            // ACT
            var result = deadlineGoalA.Equals(deadlineGoalB);

            // ASSERT
            result.ShouldBeTrue();
        }

        [Fact(DisplayName = "Equals with different values result should be false")]
        public void Equals_WithDifferentValues_ResultShouldBeFalse()
        {
            var faker = new Faker();
            var dateA = faker.Date.Future().AddDays(60);
            var dateB = faker.Date.Future().AddDays(90);
            var deadlineGoalA = new DeadlineGoal(dateA);
            var deadlineGoalB = new DeadlineGoal(dateB);

            // ACT
            var result = deadlineGoalA.Equals(deadlineGoalB);

            // ASSERT
            result.ShouldBeFalse();
        }

        [Fact(DisplayName = "Get HashCode with same values result should be consistent")]
        public void GetHashCode_WithSameValues_ResultShouldBeConsistent()
        {
            // ARRANGE
            var faker = new Faker();
            var date = faker.Date.Future().AddDays(60);
            var deadlineGoalA = new DeadlineGoal(date);
            var deadlineGoalB = new DeadlineGoal(date);
            var expectedHash = deadlineGoalA.GetHashCode();

            // ACT
            var result = deadlineGoalB.GetHashCode();

            // ASSERT
            result.ShouldBe(expectedHash);

        }

        [Fact(DisplayName = "Explicit operator with valid values result a Datetime")]
        public void ExplicitOperator_WithValidValues_ResultDatetime()
        {
            // ARRANGE
            var faker = new Faker();
            var deadlineGoal = new DeadlineGoal(faker.Date.Future().AddDays(30));

            // ACT
            var result = (DateTime)deadlineGoal;

            // ASSERT
            result.GetType().ShouldBe(typeof(DateTime));
        }

    }
}
