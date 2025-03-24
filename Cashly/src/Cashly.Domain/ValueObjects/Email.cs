using Cashly.Domain.Exceptions;
using Cashly.Domain.ValueObjects.bases;
using System.ComponentModel.DataAnnotations;

namespace Cashly.Domain.ValueObjects
{
    public sealed class Email : ValueObject<Email>
    {
        public string Value { get; }

        public Email(string value)
        {
            Validate(value);
            Value = value;
        }

        private static void Validate(string value)
        {
            var emailAttribute = new EmailAddressAttribute();
            DomainExceptionValidation.When(!emailAttribute.IsValid(value), "Email is invalid");
        }

        protected override bool EqualsCore(Email other)
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
