using Cashly.Domain.Entities.bases;
using Cashly.Domain.Exceptions;
using Cashly.Domain.ValueObjects;

namespace Cashly.Domain.Entities
{
    public sealed class Goal(Cash value, DeadlineGoal deadline, Cashflow cashflow) : Entity
    {
        public Cash Value { get; private set; } = value;
        public DateTime Start { get; private set; } = DateTime.Now;
        public DeadlineGoal Deadline { get; private set; } = deadline;

        public Cashflow Cashflow { get; set; } = cashflow;
        public int CashflowId { get;  set; } = cashflow.Id;

        public void SetStartDate(DateTime start)
        {
            DomainExceptionValidation.When(start > Deadline, "The start date cannot be later than the deadline");
            DomainExceptionValidation.When(start < DateTime.UtcNow, "The start date cannot be in the past");
            Start = start;
        }
    }
}
