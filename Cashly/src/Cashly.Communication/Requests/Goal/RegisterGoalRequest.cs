    namespace Cashly.Communication.Requests.Goal
{
    public class RegisterGoalRequest
    {
        public decimal Value { get; set; }
        public DateTimeOffset Deadline { get; set; }
    }
}
