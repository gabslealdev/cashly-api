using Cashly.Domain.Exceptions;

namespace Cashly.Domain.ValueObjects
{
    public sealed class TargetAmount
    {
        public decimal Value { get; }

        public TargetAmount(decimal value)
        {
            Value = value;
        }

        private void Validate(decimal value)
        {
            DomainExceptionValidation.When(value < 0, "This value cannot be less than zero");

        }
    }
}
