using Bogus;
using Cashly.Domain.Exceptions;
using Cashly.TestDataBuilder.DomainDataBuilder.Entities;
using Shouldly;

namespace Cashly.Domain.Tests.Entities.GoalTests;
public class GoalUnitTest
{
    [Fact(DisplayName = "Create Goal with valid parameters result object valid state")]
    public void CreateGoal_WithValidParameters_ResultObjectValidState()
    {
        // ACT
        Action action = () => GoalBuilder.BuildValidGoal();

        // ASSERT
        action.ShouldNotThrow();
    }

    [Fact(DisplayName = "Create Goal seting Dealine result object valid state")]
    public void CreateGoal_SetingDeadline_ResultObjectValidState()
    {
        // ARRANGE
        var faker = new Faker();
        var goal = GoalBuilder.BuildValidGoal();

        // ACT
        Action action = () => goal.SetDeadline(
            faker.Date.FutureOffset(refDate: (DateTimeOffset)goal.Deadline, yearsToGoForward: 1));

        // ASSERT
        action.ShouldNotThrow();
    }

    [Fact(DisplayName = "Create Goal with invalid set Dealine result DomainExceptionValidation")]
    public void CreateGoal_WithInvalidSetDeadline_ResultDomainExceptionValidation()
    {
        // ARRANGE
        var faker = new Faker();
        var goal = GoalBuilder.BuildValidGoal();

        // ACT
        Action action = () => goal.SetDeadline(faker.Date.SoonOffset());

        // ASSERT
        action.ShouldThrow<DomainExceptionValidation>().Message.ShouldBe("The new deadline cannot be earlier than the current deadline");


    }
}
