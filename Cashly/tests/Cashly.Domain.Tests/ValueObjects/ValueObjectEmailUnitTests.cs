using Bogus;
using Cashly.Domain.Exceptions;
using Cashly.Domain.ValueObjects;
using Cashly.TestDataBuilder.DomainDataBuilder.ValueObjects;
using Shouldly;

namespace Cashly.Domain.Tests.ValueObjects
{
    public class ValueObjectEmailUnitTests
    {
        [Fact(DisplayName = "Create Email with valid parameter result object valid state")]
        public void CreateEmail_WithValidParameter_ResultObjectValidState()
        {
            // ACT
            Action action = () => EmailBuilder.BuildValidEmail();

            // ASSERT
            action.ShouldNotThrow();
        }

        [Fact(DisplayName = "Create Email with invalid parameter result DomainExceptionValidation")]
        public void CreateEmail_WithInvalidParameter_ResultDomainExceptionValidation()
        {
            // ACT
            Action action = () => EmailBuilder.BuildInvalidEmail();

            // ASSERT
            action.ShouldThrow<DomainExceptionValidation>().Message.ShouldBe("Email is invalid");
        }

        [Fact(DisplayName = "Equals with same values result should be true")]
        public void Equals_WithSameValues_ResultShouldBeTrue()
        {
            // ARRANGE
            var faker = new Faker();
            var userEmail = faker.Internet.Email();
            var emailA = new Email(userEmail);
            var emailB = new Email(userEmail);

            // ACT
            var result = emailA.Equals(emailB);

            // ASSERT
            result.ShouldBe(true);
        }

        [Fact(DisplayName = "Equals with different values result should be false")]
        public void Equals_WithDifferentValues_ResultShouldBeFalse()
        {
            // ARRANGE
            var faker = new Faker();
            var emailA = new Email(faker.Internet.Email());
            var emailB = new Email(faker.Internet.Email());

            // ACT
            var result = emailA.Equals(emailB);

            // ASSERT
            result.ShouldBe(false);
        }

        [Fact(DisplayName = "GetHashCode with same email should be consistent")]
        public void GetHash_WithSameEmail_ShouldbeConsistent()
        {
            // ARRANGE
            var faker = new Faker();
            var userEmail = faker.Internet.Email();
            var emailA = new Email(userEmail);
            var emailB = new Email(userEmail);

            // ACT
            var hashA = emailA.GetHashCode();
            var HashB = emailB.GetHashCode();

            // ASSERT
            hashA.ShouldBe(HashB);
        }
    }
}
