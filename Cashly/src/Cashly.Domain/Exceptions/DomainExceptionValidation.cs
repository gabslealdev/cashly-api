﻿namespace Cashly.Domain.Exceptions
{
    public class DomainExceptionValidation : SystemException
    {
        public DomainExceptionValidation(string error) : base(error) { }

        public static void When(bool hasError, string error)
        {
            if (hasError)
                throw new DomainExceptionValidation(error);
        }

    }
}