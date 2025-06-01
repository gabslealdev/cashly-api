using Bogus;
using Cashly.Application.UseCases.Transactions.Register;
using Cashly.Communication.Requests.Transaction.Enum;
using Cashly.TestDataBuilder.CommunicationDataBuilder.Transaction.Request;
using Shouldly;

namespace Cashly.Aplication.Tests.Validator.Transaction.Request
{
    public class RequestTransactionValidatorTests
    {
        [Fact(DisplayName = "Request transaction validator with valid parameters result success")]
        public void RequestTransactionValidator_WithValidParameters_ResultSuccess()
        {
            // ARRANGE
            var validator = new RegisterTransactionValidator();
            var request = RegisterTransactionRequestBuilder.Build();

            // ACT
            var result = validator.Validate(request);

            // ASSERT
            result.IsValid.ShouldBeTrue();
        }

        [Theory(DisplayName = "Request transaction validator with zero amount result IsValid False")]
        [InlineData (0)]
        [InlineData(-4)]
        public void RequestTransactionValidator_WithZeroAmount_ResultIsValidFalse(decimal amount)
        {
            // ARRANGE
            var validator = new RegisterTransactionValidator();
            var request = RegisterTransactionRequestBuilder.Build();
            request.Amount = amount;

            // ACT
            var result = validator.Validate(request);

            // ASSERT
            result.IsValid.ShouldBeFalse();
        }

        [Fact(DisplayName = "Request transaction validator with empty date result IsValid False")]
        public void RequestTransactionValidator_WithEmptyDate_ResultIsValidFalse()
        {
            // ARRANGE
            var  faker = new Faker();
            var validator = new RegisterTransactionValidator();
            var request = RegisterTransactionRequestBuilder.Build();
            request.Type = (TransactionTypeRequest)faker.Random.Int(min: 3, max: 12);

            // ACT
            var result = validator.Validate(request);

            // ASSERT
            result.IsValid.ShouldBeFalse();
        }

        [Theory(DisplayName = "Request transaction validator with invalid category IsValid False")]
        [InlineData("   ")]
        [InlineData(null)]
        [InlineData("")]
        public void RequestTransactionValidator_WithInvalidCategory_ResultIsValidFalse(string newCategory)
        {
            // ARRANGE
            var faker = new Faker();
            var validator = new RegisterTransactionValidator();
            var request = RegisterTransactionRequestBuilder.Build();
            request.CreatedCategoryId = null;
            request.NewCategoryName = string.Empty;

            // ACT
            var result = validator.Validate(request);

            // ASSERT
            result.IsValid.ShouldBeFalse();
        }

    }
}
