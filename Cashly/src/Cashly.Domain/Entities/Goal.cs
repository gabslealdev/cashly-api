using Cashly.Domain.Entities.bases;
using Cashly.Domain.Exceptions;
using Cashly.Domain.ValueObjects;

namespace Cashly.Domain.Entities;
public sealed class Goal(int id, Cash value, DeadlineGoal deadline, Cashflow cashflow) : Entity(id)
{
    public Cash Value { get; private set; } = value;
    public DateTime StartDate { get; } = DateTime.UtcNow;
    public DeadlineGoal Deadline { get; private set; } = deadline;
    public Cashflow Cashflow { get; set; } = cashflow;
    public int CashflowId { get; set; } = cashflow.Id;

    public void SetDeadline(DateTime date)
    {
        DomainExceptionValidation.When(date <= Deadline, "The new deadline cannot be earlier than the current deadline");
        Deadline = new DeadlineGoal(date);
    }

}
    