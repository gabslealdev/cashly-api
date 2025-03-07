using Cashly.Domain.Exceptions;

namespace Cashly.Domain.ValueObjects
{
    public sealed class CategoryName
    {
        public string Value { get; }

        public CategoryName(string value)
        {
           Validate(value);
           Value = value;
        }

        private void Validate(string value)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(value), "Error: Name cannot be empty");
            DomainExceptionValidation.When(value.Length < 3, "Error: Name must be longer than 3 characters.");
        }


        public override string ToString() => Value;

        public override bool Equals(object? obj) => obj is CategoryName other && Value == other.Value;

        public override int GetHashCode() => Value.GetHashCode();
    }
}
