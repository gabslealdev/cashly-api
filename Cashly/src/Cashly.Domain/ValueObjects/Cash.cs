using Cashly.Domain.Exceptions;
using Cashly.Domain.ValueObjects.bases;

namespace Cashly.Domain.ValueObjects
{
    public sealed class Cash : ValueObject<Cash>
    {
        public decimal Value { get; }

        public Cash(decimal value)
        {
            Validate(value);
            Value = value;
        }

        private static void Validate(decimal value)
        {
            DomainExceptionValidation.When(value < 0, "Value must be greater than zero");
        }

        public static Cash operator +(Cash c1, Cash c2)
        {
            Cash sum = new Cash(c1.Value + c2.Value);
            return sum;
        }
        public static Cash operator -(Cash c1, Cash c2)
        {
            if (c1.Value < c2.Value)
                throw new InvalidOperationException("Result of the operation must be greater than 0");

            Cash sub = new Cash(c1.Value - c2.Value);
            return sub;
        }
        public override string ToString() => $"R$ {Value:N2}";
        public override bool Equals(object? obj) => obj is Cash other && Value == other.Value;
        public override int GetHashCode() => Value.GetHashCode();
        public int CompareTo(Cash? other)
        {
            if (other is null) throw new ArgumentNullException(nameof(other));
            return Value.CompareTo(other.Value);
        }

        public static explicit operator decimal(Cash cash) => cash.Value;
        protected override bool EqualsCore(Cash other)
        {
            return Value == other.Value;
        }
        protected override decimal GetHashCodeCore()
        {
            decimal hashCode = Value.GetHashCode();
            return hashCode;
        }
    }
}
