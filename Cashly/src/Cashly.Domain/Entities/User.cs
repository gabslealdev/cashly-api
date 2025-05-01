using Cashly.Domain.Entities.bases;
using Cashly.Domain.ValueObjects;

namespace Cashly.Domain.Entities;

public sealed class User(int id, Name name, Email email, string passwordHash) : Entity(id)
{
    public Name Name { get; private set; } = name;
    public Email Email { get; private set; } = email;
    public string PasswordHash { get; private set; } = passwordHash;
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;
    public Cashflow? Cashflow { get; set; }
    public int? CashflowId { get; set; }
}
