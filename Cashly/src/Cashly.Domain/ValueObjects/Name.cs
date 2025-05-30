﻿using Cashly.Domain.Exceptions;
using Cashly.Domain.ValueObjects.bases;

namespace Cashly.Domain.ValueObjects
{
    public sealed class Name: ValueObject<Name>
    {
        public string Value { get; }

        public Name(string value)
        {
           Validate(value);
           Value = value;
        }

        private void Validate(string value)
        {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(value), "Name cannot be null or empty");
            DomainExceptionValidation.When(value.Length < 3, "Name must be longer than 3 characters");
        }


        public override string ToString() => Value;

        protected override bool EqualsCore(Name other)
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
