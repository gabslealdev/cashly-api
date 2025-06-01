using Bogus;
using Cashly.Communication.Requests.User;

namespace Cashly.TestDataBuilder.CommunicationDataBuilder.User.Request
{
    public class RegisterUserRequestBuilder
    {
        public static RegisterUserRequest Build()
        {
            var faker = new Faker();

            return new RegisterUserRequest
            {
                Name = faker.Commerce.ProductName(),
                Email = faker.Internet.Email(),
                Password = GeneratePassword(faker),
            };
        } 

        private static string GeneratePassword(Faker faker)
        {
            string upper = faker.Random.Char('A', 'Z').ToString();
            string lower = faker.Random.Char('a', 'z').ToString();
            string digit = faker.Random.Int(0, 9).ToString();
            string special = faker.PickRandom("!@#$%^&*()_+-=[]{}|;':\",.<>/?").ToString();
            int totalLength = 8;
            int othersLength = Math.Max(0, totalLength - 4);
            string others = faker.Random.String2(othersLength, "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()");
            string password = upper + lower + digit + special + others;
            string shuffledPassword = new string(password.OrderBy(c => faker.Random.Int()).ToArray());


            return shuffledPassword;
        }
    }
}
