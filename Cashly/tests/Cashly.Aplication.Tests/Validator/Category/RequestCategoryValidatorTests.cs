using Bogus;
using Cashly.Application.UseCases.Categories.Register;
using Cashly.Communication.Requests.RequestRegisterCategory;
using Cashly.TestDataBuilder.CommunicationDataBuilder.Category.Request;
using Shouldly;

namespace Cashly.Aplication.Tests.Validator.Category
{
    public class RequestCategoryValidatorTests
    {
        [Fact(DisplayName = "Request category validator with valid parameters result success")]
        public void RequestCategoryValidator_WithValidParameters_ResultSuccess()
        {
            // ARRANGE
            var validator = new RegisterCategoryValidator();
            var request = RegisterCategoryRequestBuilder.Build();

            // ACT 
            var result = validator.Validate(request);

            // ASSERT
            result.IsValid.ShouldBeTrue();
        }
        [Fact (DisplayName = "Request Category validator with invalid name result IsValid false")]
        public void RequestCategorValidator_WithInvalidName_ResultIsValidFalse()
        {
            // ARRANGE
            var faker = new Faker();
            var validator = new RegisterCategoryValidator();
            var request = RegisterCategoryRequestBuilder.Build();
            request.Name = string.Empty;

            // ACT
            var result = validator.Validate(request);

            // ASSERT
            result.IsValid.ShouldBeFalse();
        }
    }
}
