namespace Cashly.Domain.Entities.bases;

public abstract class Entity
{
    public virtual int Id { get; protected set; }

    public override bool Equals(object? obj)
    {
        if (obj is not Entity other)
            return false;

        if (ReferenceEquals(other, this))
            return true;

        if(Id == 0 || other.Id == 0)
            return false;

        return Id == other.Id;
    }

    public static bool operator ==(Entity x, Entity y)
    {
        if (x is null && y is null)
            return true;

        if (x is null || y is null)
            return false;

        return x.Equals(y);
    }

    public static bool operator !=(Entity x, Entity y)
    { 
        return !(x == y);
    }

    public override int GetHashCode()
    {
        return (GetType().ToString() + Id).GetHashCode();
    }

}
