using Cashly.Domain.Entities;
using Cashly.Domain.Exceptions;
using Cashly.Domain.ValueObjects;
using Shouldly;

namespace Cashly.Domain.Tests.GoalTests
{
    public class GoalUnitTest
    {
        [Fact(DisplayName = "Create Goal with valid parameters result object valid state")]
        public void CreateGoal_WithValidParameters_ResultObjectValidState()
        {
            // ARRANGE
            var userId = 1;
            var name = new Name("Andressa");
            var email = new Email("adeandressa@gmail.com");
            var passwordHash = "sTrINgQUalquER";
            var user = new User(userId, name, email, passwordHash);

            var cashflowId = 1;
            var cashflow = new Cashflow(cashflowId, user);
            var date = new DateTime(2025, 06, 06, 18, 00, 00, DateTimeKind.Utc);


            // ACT
            Action action = () => new Goal(1, new Cash(800.00m), new DeadlineGoal(date), cashflow);

            // ASSERT
            action.ShouldNotThrow();
        }

        [Fact(DisplayName = "Create Goal with invalid deadline result DomainExceptionValidation")]
        public void CreateGoal_WithInvalidDeadline_ResultDomainExceptionValidation()
        {
            // ARRANGE
            var userId = 1;
            var name = new Name("Andressa");
            var email = new Email("adeandressa@gmail.com");
            var passwordHash = "sTrINgQUalquER";
            var user = new User(userId, name, email, passwordHash);

            var cashflowId = 1;
            var cashflow = new Cashflow(cashflowId, user);
            var date = new DateTime(2025, 05, 02, 18, 00, 00, DateTimeKind.Utc);


            // ACT
            Action action = () => new Goal(1, new Cash(800.00m), new DeadlineGoal(date), cashflow);

            // ASSERT
            action.ShouldThrow<DomainExceptionValidation>().Message.ShouldBe("Deadline must be at least 30 days after from now.");
        }

        [Fact(DisplayName = "Create Goal seting Dealine result object valid state")]
        public void CreateGoal_SetingDeadline_ResultObjectValidState()
        {
            // ARRANGE
            var userId = 1;
            var name = new Name("Marcos Paulo");
            var email = new Email("mpsilva@gmail.com");
            var passwordHash = "sTrINgQUalquER";
            var user = new User(userId, name, email, passwordHash);

            var cashflowId = 1;
            var cashflow = new Cashflow(cashflowId, user);

            var goalId = 1;
            var value = new Cash(1000.00m);
            var date = new DeadlineGoal(DateTime.UtcNow.AddDays(31));
            var goal = new Goal(goalId, value, date, cashflow);

            // ACT
            Action action = () => goal.SetDeadline(DateTime.UtcNow.AddDays(90));

            // ASSERT
            action.ShouldNotThrow();


        }

        [Fact(DisplayName = "Create Goal with invalid set Dealine result DomainExceptionValidation")]
        public void CreateGoal_WithInvalidSetDeadline_ResultDomainExceptionValidation()
        {
            // ARRANGE
            var userId = 1;
            var name = new Name("Marcos Paulo");
            var email = new Email("mpsilva@gmail.com");
            var passwordHash = "sTrINgQUalquER";
            var user = new User(userId, name, email, passwordHash);

            var cashflowId = 1;
            var cashflow = new Cashflow(cashflowId, user);


            var goalId = 1;
            var value = new Cash(1000.00m);
            var date = new DeadlineGoal(DateTime.UtcNow.AddDays(31));
            var goal = new Goal(goalId, value, date, cashflow);


            // ACT
            Action action = () => goal.SetDeadline(DateTime.UtcNow.AddDays(30));

            // ASSERT
            action.ShouldThrow<DomainExceptionValidation>().Message.ShouldBe("The new deadline cannot be earlier than the current deadline");


        }
    }
}
        