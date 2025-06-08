using Cashly.Domain.Exceptions;
using Cashly.Domain.ValueObjects.bases;

namespace Cashly.Domain.ValueObjects
{
    public sealed class DeadlineGoal: ValueObject<DeadlineGoal>
    {
        public DateTimeOffset Date { get; }

        public DeadlineGoal(DateTimeOffset date)
        {
            Validate(date);
            Date = date;
        }

        private static void Validate(DateTimeOffset date) => DomainExceptionValidation.When(date <= DateTimeOffset.Now.Date.AddDays(30), "Deadline must be at least 30 days after from now");

        protected override bool EqualsCore(DeadlineGoal other)
        {
            return Date == other.Date;
        }

        protected override decimal GetHashCodeCore()
        {
            decimal hashCode = Date.GetHashCode();
            return hashCode;
        }

        public static implicit operator DateTimeOffset(DeadlineGoal deadlineGoal) => deadlineGoal.Date;
    }
}
