using Cashly.Domain.ValueObjects;
using Cashly.Domain.Entities;
using Shouldly;
using Cashly.Domain.Exceptions;
using Cashly.TestFixtures.Fixtures.Entities;


namespace Cashly.Domain.Tests.Entities.UserTests
{
    public class UserUnitTest
    {
        [Fact(DisplayName = "Create user with valid state")]
        public void CreateUser_WithValidParameter_ResultObjectValidState()
        {
            // ACT
            Action action = () => UserFixture.CreateValidUser();

            // ASSERT
            action.ShouldNotThrow();
        }

    }
}

