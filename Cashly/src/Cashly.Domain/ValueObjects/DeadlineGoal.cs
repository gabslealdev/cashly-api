﻿using Cashly.Domain.Exceptions;
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

        private static void Validate(DateTime date) => DomainExceptionValidation.When(date <= DateTime.UtcNow.AddDays(30), "Deadline must be at least 30 days after from now");

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
