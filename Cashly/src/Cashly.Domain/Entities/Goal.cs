using Cashly.Domain.Entities.bases;
using Cashly.Domain.Exceptions;
using Cashly.Domain.ValueObjects;

namespace Cashly.Domain.Entities;
public sealed class Goal: Entity
{
    public Cash Value { get; private set; }
    public DateTimeOffset StartDate { get; } = DateTimeOffset.UtcNow;
    public DeadlineGoal Deadline { get; private set; }
    public Cashflow Cashflow { get; set; } 
    public int CashflowId { get; set; }

    public Goal(int id, Cash value, DeadlineGoal deadline, Cashflow cashflow) : base(id)
    {
        Value = value;
        Deadline = deadline;
        Cashflow = cashflow;
    }

    private Goal() { }

    public void SetDeadline(DateTimeOffset date)
    {
        DomainExceptionValidation.When(date <= Deadline, "The new deadline cannot be earlier than the current deadline");
        Deadline = new DeadlineGoal(date);
    }
}
    