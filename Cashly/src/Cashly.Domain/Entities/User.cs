using Cashly.Domain.Entities.bases;
using Cashly.Domain.Exceptions;
using Cashly.Domain.ValueObjects;

namespace Cashly.Domain.Entities;

public sealed class User : Entity
{
    public Name Name { get; private set; }
    public Email Email { get; private set; }
    public string PasswordHash { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset UpdatedAt { get; private set; } = DateTimeOffset.UtcNow;
    public Cashflow? Cashflow { get; private set; }

    public User(int id, Name name, Email email, string passwordHash) : base(id) 
    {
        Name = name;
        Email = email;
        ValidatePasswordHash(passwordHash);
        PasswordHash = passwordHash;
    }
    private User(){}

    private void ValidatePasswordHash(string passwordHash)
    {
        DomainExceptionValidation.When(string.IsNullOrWhiteSpace(passwordHash), "Password cannot be null or empty");
    }
}
