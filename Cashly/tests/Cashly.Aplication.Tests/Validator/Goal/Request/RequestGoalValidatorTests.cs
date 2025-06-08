using Cashly.Application.UseCases.Goals.Register;
using Cashly.TestDataBuilder.CommunicationDataBuilder.Goal.Request;
using Shouldly;

namespace Cashly.Aplication.Tests.Validator.Goal.Request
{
    public class RequestGoalValidatorTests
    {
        [Fact(DisplayName = "Request goal validator with valid parameters result success")]
        public void RequestGoalValidator_WithValidParameters_ResultSuccess()
        {
            // ARRANGE
            var validator = new RegisterGoalValidator();
            var request = RegisterGoalRequestBuilder.Build();

            // ACT
            var result = validator.Validate(request);

            // ASSERT
            result.IsValid.ShouldBeTrue();
        }

        [Theory(DisplayName = "Request goal validator with invalid value result IsValid false")]
        [InlineData(0)]
        [InlineData(-1)]
        public void RequestGoalValidator_WithInvalidValue_ResultIsValidFalse(decimal value)
        {
            // ARRANGE
            var validator = new RegisterGoalValidator();
            var request = RegisterGoalRequestBuilder.Build();
            request.Value = value;

            // ACT
            var result = validator.Validate(request);

            // ASSERT
            result.IsValid.ShouldBeFalse();
        }

        [Fact(DisplayName = "Request goal validator with invalid deadline parameters result IsValid false")]
        public void RequestGoalValidator_WithInvalidDeadline_ResultIsValidFalse()
        {
            // ARRANGE
            var validator = new RegisterGoalValidator();
            var request = RegisterGoalRequestBuilder.Build();
            request.Deadline = DateTimeOffset.UtcNow;

            // ACT
            var result = validator.Validate(request);

            // ASSERT
            result.IsValid.ShouldBeFalse();
        }
    }
}
