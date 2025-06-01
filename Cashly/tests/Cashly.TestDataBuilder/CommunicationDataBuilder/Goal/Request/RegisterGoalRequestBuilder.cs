using Bogus;
using Cashly.Communication.Requests.Goal;

namespace Cashly.TestDataBuilder.CommunicationDataBuilder.Goal.Request
{
    public class RegisterGoalRequestBuilder
    {
        public static RegisterGoalRequest Build()
        {
            var faker = new Faker();

            return new RegisterGoalRequest
            {
                Value = faker.Random.Decimal(400, 7000),
                Deadline = faker.Date.Future(refDate: DateTime.Today.AddDays(31))
            };
        }
    }
}
