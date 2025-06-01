using Cashly.TestDataBuilder.DomainDataBuilder.Entities;
using Shouldly;


namespace Cashly.Domain.Tests.Entities.UserTests
{
    public class UserUnitTest
    {
        [Fact(DisplayName = "Create user with valid state")]
        public void CreateUser_WithValidParameter_ResultObjectValidState()
        {
            // ACT
            Action action = () => UserBuilder.BuildValidUser();

            // ASSERT
            action.ShouldNotThrow();
        }

    }
}

