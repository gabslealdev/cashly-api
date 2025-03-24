namespace Cashly.Domain.ValueObjects.bases
{
    public abstract class ValueObject<T> where T : ValueObject<T>
    {
        public override bool Equals(object? obj)
        {
            if (obj is not T valueObject)
                return false;

            return EqualsCore(valueObject);
        }
        protected abstract bool EqualsCore(T other);
        public override int GetHashCode() => (int)GetHashCodeCore();
        protected abstract decimal GetHashCodeCore();

        public static bool operator ==(ValueObject<T> x, ValueObject<T> y)
        {
            if (x is null && y is null)
                return true;

            if (x is null || y is null)
                return false;

            return x.Equals(y);
        }

        public static bool operator !=(ValueObject<T> x, ValueObject<T> y)
        {
            return !(x == y);
        }


    }
}
