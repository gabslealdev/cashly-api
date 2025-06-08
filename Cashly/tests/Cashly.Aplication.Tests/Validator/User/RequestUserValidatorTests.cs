using Bogus;
using Cashly.Application.UseCases.Users.Register;
using Cashly.Communication.Requests.User;
using Cashly.TestDataBuilder.CommunicationDataBuilder.User.Request;
using Shouldly;

namespace Cashly.Aplication.Tests.Validator.User
{
    public class RequestUserValidatorTests
    {
        [Fact(DisplayName = "Request user validator with valid parameters result success")]
        public void RequestUserValidatorWithValidParametersResultSuccess()
        {
            // ARRANGE
            var validator = new RegisterUserValidator();
            var request = RegisterUserRequestBuilder.Build();

            // ACT
            var result = validator.Validate(request);

            // ASSERT
            result.IsValid.ShouldBeTrue();
        }

        [Fact(DisplayName = "Request user validator with empty name result IsValid false")]
        public void RequestUserValidator_WithEmptyName_ResultIsValidFalse()
        {
            // ARRANGE
            var validator = new RegisterUserValidator();
            var request = RegisterUserRequestBuilder.Build();
            request.Name = string.Empty;

            // ACT
            var result = validator.Validate(request);

            // ASSERT
            result.IsValid.ShouldBeFalse();
        }

        [Fact(DisplayName = "Request user validator with invalid name result IsValid false")]
        public void RequestUserValidator_WithInvalidName_ResultIsValidFalse()
        {
            // ARRANGE
            var faker = new Faker();
            var validator = new RegisterUserValidator();
            var request = RegisterUserRequestBuilder.Build();
            request.Name = faker.Random.String(2);

            // ACT
            var result = validator.Validate(request);

            // ASSERT
            result.IsValid.ShouldBeFalse();
        }

        [Fact(DisplayName = "Request user validator with invalid email format result IsValid false")]
        public void RequestUserValidator_WithInvalidEmailFormat_ResultIsValidFalse()
        {
            // ARRANGE
            var faker = new Faker();
            var validator = new RegisterUserValidator();
            var request = RegisterUserRequestBuilder.Build();
            request.Email = faker.Random.String(12);

            // ACT
            var result = validator.Validate(request);

            // ASSERT
            result.IsValid.ShouldBeFalse();
        }

        [Fact(DisplayName = "Request user validator with empty password result IsValid false")]
        public void RequestUserValidator_WithEmptyPassword_ResultIsValidFalse()
        {
            // ARRANGE
            var faker = new Faker();
            var validator = new RegisterUserValidator();
            var request = RegisterUserRequestBuilder.Build();
            request.Password = " ";

            // ACT
            var result = validator.Validate(request);

            // ASSERT
            result.IsValid.ShouldBeFalse();
        }

        [Fact(DisplayName = "Request user validator with invalid password format result IsValid false")]
        public void RequestUserValidator_WithInvalidPasswordFormat_ResultIsValidFalse()
        {
            // ARRANGE
            var faker = new Faker();
            var validator = new RegisterUserValidator();
            var request = RegisterUserRequestBuilder.Build();
            request.Password = faker.Internet.Password();

            // ACT
            var result = validator.Validate(request);

            // ASSERT
            result.IsValid.ShouldBeFalse();
        }

    }
}
