using Cashly.Domain.ValueObjects;
using Cashly.Domain.Entities;
using Shouldly;
using Cashly.Domain.Exceptions;


namespace Cashly.Domain.Tests.UserTests
{
    public class UserUnitTest
    {
        [Fact(DisplayName = "Create user with valid state")]
        public void CreateUser_WithValidParameter_ResultObjectValidState()
        {
            // ARRANGE
            var id = 4;
            var name = new Name("Anderson");
            var email = new Email("andersongoes94@gmail.com");
            var passwordHash = "RanDomHaSH34jUStoTTeST01543";

            // ACT
            Action action = () => new User(id, name, email, passwordHash);

            // ASSERT
            action.ShouldNotThrow();
        }

        [Fact(DisplayName = "Create User testing created at and updated at")]
        public void CreateUser_TestingCreatedAtAndUpdatedAt()
        {
            // ARRANGE
            var now = DateTime.UtcNow;
            var id = 4;
            var name = new Name("Anderson");
            var email = new Email("andersongoes94@gmail.com");
            var passwordHash = "RanDomHaSH34jUStoTTeST01543";
            var user = new User(id, name, email,passwordHash);
            

            //ASSERT
            user.CreatedAt.ShouldBeInRange(now, DateTime.UtcNow.AddSeconds(1));
            user.UpdatedAt.ShouldBeInRange(now, DateTime.UtcNow.AddSeconds(1));


        }
        
        [Fact(DisplayName = "Create user with invalid e-mail")]
        public void CreateUser_WithInvalidEmail_DomainExceptionValidation()
        {
            // ARRANGE
            var id = 4;
            var name = new Name("Anderson");
            var passwordHash = "RanDomHaSH34jUStoTTeST01543";

            // ACT
            Action action = () => new User(id, name, new Email("fail.com") ,passwordHash);

            // ASSERT
            action.ShouldThrow<DomainExceptionValidation>().Message.ShouldBe("Email is invalid");
        }
    }
}

