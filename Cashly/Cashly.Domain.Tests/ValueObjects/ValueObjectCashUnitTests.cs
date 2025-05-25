using Bogus;
using Cashly.Domain.Exceptions;
using Cashly.Domain.ValueObjects;
using Cashly.TestFixtures.Fixtures.ValueObjects;
using Shouldly;

namespace Cashly.Domain.Tests.ValueObjects
{
    public class ValueObjectCashUnitTests
    {
        [Fact(DisplayName = "Create a cash with valid parameters result value object")]
        public void CreateCash_WithValidParameters_ResultValueObject()
        {
            // ACT 
            Action action = () => CashFixture.CreateValidCash();

            // ASSERT
            action.ShouldNotThrow();
        }

        [Fact(DisplayName = "Create a cash with invalid parameters result DomainExceptionValidation")]
        public void CreateCash_WithInvalidParameters_ResultDomainExceptionValidation()
        {
            // ACT 
            Action action = () => CashFixture.CreateInvalidCash();

            // ASSERT
            action.ShouldThrow<DomainExceptionValidation>().Message.ShouldBe("Value must be greater than zero");
        }

        [Fact(DisplayName = "Sum operator with two valid values result object valid state")]
        public void SumOperator_WithTwoValidValues_ResultObjectValidState()
        {
            // ARRANGE
            var faker = new Faker();

            var amountA = faker.Finance.Amount();
            var amountB = faker.Finance.Amount();

            var cashA = new Cash(amountA);
            var cashB = new Cash(amountB);
            
            var expected = amountA + amountB;

            // ACT 
            var result = cashA + cashB;

            // ASSERT
            result.Value.ShouldBe(expected);
        }

        [Fact(DisplayName = "Subtraction operator with two valid values result object valid state")]
        public void SubtractionOperator_WithTwoValidValues_ResultObjectValidState()
        {
            // ARRANGE
            var faker = new Faker();

            var amountA = faker.Finance.Amount(900.00m, 1000.00m);
            var amountB = faker.Finance.Amount(1.00m, 100.00m);

            var cashA = new Cash(amountA);
            var cashB = new Cash(amountB);

            var expected = amountA - amountB;

            // ACT 
            var result = cashA - cashB;

            // ASSERT
            result.Value.ShouldBe(expected);
        }

        [Fact(DisplayName = "Substraction operator with two invalid values result InvalidOperationException")]
        public void SubtractionOperator_WithTwoInvalidValues_ResultInvalidOperationException()
        {
            // ARRANGE
            var faker = new Faker();

            var amountB = faker.Finance.Amount(900.00m, 1000.00m);
            var amountA = faker.Finance.Amount(1.00m, 100.00m);

            var cashA = new Cash(amountA);
            var cashB = new Cash(amountB);

            var expected = amountA - amountB;

            // ACT 
            Action action = () => { var _ = cashA - cashB; };

            // ASSERT
            action.ShouldThrow<InvalidOperationException>().Message.ShouldBe("Result of the operation must be greater than 0");
        }

        [Fact(DisplayName = "Convert to string With Brazilian Currency should be consistent")]
        public void ToString_WithBrazilianCurrency_ShouldBeConsistent()
        {
            // ARRANGE 
            var faker = new Faker();
            var amount = faker.Finance.Amount();
            var cash = new Cash(amount);

            // ACT 
            var result = cash.ToString();

            // ASSERT
            result.ShouldBe($"R$ {amount:N2}");
        }

        [Fact(DisplayName = "Equals with same values result should be True")]
        public void Equals_WithSameValues_ResultShouldBeTrue()
        {
            // ARRANGE
            var faker = new Faker();
            var value = faker.Random.Decimal(0.99m, 1000.00m); 
            var cashA = new Cash(value);
            var cashB = new Cash(value);

            // ACT 
            var result = cashA.Equals(cashB);

            // ASSERT 
            result.ShouldBeTrue();
        }

        [Fact(DisplayName = "Equals with Different values result should be False")]
        public void Equals_WithDifferentValues_ResultShouldBeFalse()
        {
            // ARRANGE
            var faker = new Faker();
            var value = faker.Random.Decimal(0.99m, 500.00m);
            var cash = new Cash(faker.Random.Decimal(501.00m, 1000.00m));

            // ACT 
            var result = cash.Equals(value);

            // ASSERT 
            result.ShouldBeFalse();
        }

        [Fact(DisplayName = "Explicit operator with valid values result a decimal value")]
        public void ExplictOperator_WithValidValues_ResultDecimalValue()
        {
            // ARRANGE
            var faker = new Faker();
            var cash = new Cash(faker.Random.Decimal());

            // ACT
            var result = (decimal)cash;

            // ASSERT
            result.GetType().ShouldBe(typeof(decimal));    
        }

        [Fact(DisplayName = "CompareTo with smaller Cash result negative value")]
        public void CompareTo_WithSmallerCash_ResultNegativeValue()
        {
            // ARRANGE
            var faker = new Faker();
            var cashA = new Cash(faker.Random.Decimal(400m, 600m));
            var cashB = new Cash(faker.Random.Decimal(700.00m, 1000.00m));

            // ACT
            var result = cashA.CompareTo(cashB);

            // ASSERT
            result.ShouldBeLessThan(0);
        }

        [Fact(DisplayName = "CompareTo with equal Cash result should be zero")]
        public void CompareTo_WithEqualCash_ShouldBeZero()
        {
            // ARRANGE
            var faker = new Faker();
            var value = faker.Random.Decimal();
            var cashA = new Cash(value);
            var cashB = new Cash(value);

            // ACT
            var result = cashA.CompareTo(cashB);

            // ASSERT
            result.ShouldBe(0);
        }

        [Fact(DisplayName = "CompareTo with greater Cash result positive value")]
        public void CompareTo_WithGreaterCash_ResultPositiveValue()
        {
            // ARRANGE
            var faker = new Faker();
            var cashA = new Cash(faker.Random.Decimal(400m, 600m));
            var cashB = new Cash(faker.Random.Decimal(700.00m, 1000.00m));

            // ACT
            var result = cashB.CompareTo(cashA);

            // ASSERT
            result.ShouldBeGreaterThan(0);
        }

        [Fact(DisplayName = "CompareTo with Invalid values result ArgumentNullException")]
        public void CompareTo_WithInvalidValues_ResultArgumentNullException()
        {
            // ARRANGE
            var faker = new Faker();
            Cash cashA = null;
            var cashB = new Cash(faker.Random.Decimal(700.00m, 1000.00m));

            // ACT
            Action action = () => { cashB.CompareTo(cashA); };

            // ASSERT
            action.ShouldThrow<ArgumentNullException>();

        }

        [Fact(DisplayName = "Get HashCode with same values result should be consistent")]
        public void GetHashCode_WithSameValues_ResultShouldBeConsistent()
        {
            // ARRANGE
            var faker = new Faker();
            var value = faker.Random.Decimal();
            var cashA = new Cash(value);
            var cashB = new Cash(value);
            var expectedHash = cashA.GetHashCode();

            // ACT
            var result = cashB.GetHashCode();

            // ASSERT
            result.ShouldBe(expectedHash);
        }
    }
}
