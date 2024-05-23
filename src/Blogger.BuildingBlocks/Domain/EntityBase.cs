namespace Blogger.BuildingBlocks.Domain;

public abstract class EntityBase<TId> where TId : notnull
{
    public TId Id { get; protected set; }

    protected EntityBase(TId id)
    {
        Id = id;
    }

    public override bool Equals(object? obj)
        => obj is not null &&
           obj is EntityBase<TId> entity &&
           obj.GetType() == GetType() &&
           Id.Equals(entity.Id);

    public static bool operator ==(EntityBase<TId> left, EntityBase<TId> right)
        => left.Equals(right);

    public static bool operator !=(EntityBase<TId> left, EntityBase<TId> right)
        => !left.Equals(right);

    public override int GetHashCode()
        => HashCode.Combine(GetType(), Id);
}