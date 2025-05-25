using Bogus;
using Cashly.Domain.Exceptions;
using Cashly.Domain.ValueObjects;
using Cashly.TestFixtures.Fixtures.ValueObjects;
using Shouldly;

namespace Cashly.Domain.Tests.ValueObjects
{
    public class ValueObjectNameUnitTests
    {
        [Fact(DisplayName = "Create name with valid parameters")]
        public void CreateName_WithValidParameters_ResultValueObject()
        {
            Action action = () => NameFixture.CreateValidName();

            action.ShouldNotThrow();
        }

        [Fact(DisplayName = "Create name with invalid parameters result DomainExceptionValidation")]
        public void CreateName_WithShortLength_ResultDomainExceptionValidation()
        {
            Action action = () => NameFixture.CreateInvalidNameWithShortLength();

            action.ShouldThrow<DomainExceptionValidation>().Message.ShouldBe("Name must be longer than 3 characters");
        }

        [Fact(DisplayName = "Create name with invalid parameters result DomainExceptionValidation")]
        public void CreateName_WithNullorWhiteSpaceValue_ResultDomainExceptionValidation()
        {
            Action action = () => NameFixture.CreateInvalidNameWithNullOrWhiteSpaceValue();

            action.ShouldThrow<DomainExceptionValidation>().Message.ShouldBe("Name cannot be null or empty");
        }

        [Fact(DisplayName = "To string should match input value when constructed with valid name")]
        public void ToString_ShouldMatchInputValue_WhenConstructedWithValidName()
        {
            // ARRANGE
            var faker = new Faker();
            var expectedName = faker.Name.FirstName();
            var name = new Name(expectedName);

            //ACT
            var result = name.ToString();

            //ASSERT
            result.ShouldBe(expectedName);
        }

        [Fact(DisplayName = "Compare equals name should return true")]
        public void CompareEqualsName_ShouldReturnTrue()
        {
            // ARRANGE
            var faker = new Faker();
            var firstName = faker.Name.FirstName();
            var nameA = new Name(firstName);
            var nameB = new Name(firstName);

            // ACT
            var result = nameA.Equals(nameB);

            // ASSERT
            result.ShouldBe(true);
        }

        [Fact(DisplayName = "Compare differents name should return false")]
        public void CompareDifferentsName_ShouldReturnFalse()
        {
            // ARRANGE
            var faker = new Faker();
            var firstNameA = faker.Name.FirstName();
            var firstNameB = faker.Name.FirstName();
            var nameA = new Name(firstNameA);
            var nameB = new Name(firstNameB);

            // ACT
            var result = nameA.Equals(nameB);

            // ASSERT
            result.ShouldBe(false);
        }

        [Fact(DisplayName = "GetHashCode with same Name should be consistent")]
        public void GetHash_WithSameName_ShouldbeConsistent()
        {
            // ARRANGE
            var faker = new Faker();
            var firstName = faker.Name.FirstName();
            var name = new Name(firstName);

            // ACT
            var hashA = name.GetHashCode();
            var hashB = name.GetHashCode();

            // ASSERT
            hashA.ShouldBe(hashB);
        }

    }
}
