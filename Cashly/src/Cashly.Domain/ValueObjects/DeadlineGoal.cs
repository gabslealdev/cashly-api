using Cashly.Domain.Exceptions;
using Cashly.Domain.ValueObjects.bases;

namespace Cashly.Domain.ValueObjects
{
    public sealed class DeadlineGoal: ValueObject<DeadlineGoal>
    {
        public DateTime Date { get; }

        public DeadlineGoal(DateTime date)
        {
            Validate(date);
            Date = date;
        }

        private static void Validate(DateTime date) => DomainExceptionValidation.When(date <= DateTime.UtcNow, "The target deadline cannot be in the past");

        protected override bool EqualsCore(DeadlineGoal other)
        {
            return Date == other.Date;
        }

        protected override decimal GetHashCodeCore()
        {
            decimal hashCode = Date.GetHashCode();
            return hashCode;
        }

        public static implicit operator DateTime(DeadlineGoal deadlineGoal) => deadlineGoal.Date;


    }
}
