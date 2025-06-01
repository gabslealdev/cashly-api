using Bogus;
using Cashly.Communication.Requests.RequestRegisterCategory;

namespace Cashly.TestDataBuilder.CommunicationDataBuilder.Category.Request
{
    public class RegisterCategoryRequestBuilder
    {
        public static RegisterCategoryRequest Build()
        {
            var faker = new Faker();

            return new RegisterCategoryRequest
            {
                Name = faker.Commerce.ProductName(),
                Description = faker.Commerce.ProductAdjective()
            };      
        }
    }
}
