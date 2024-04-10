namespace Blogger.Domain.Common;

public abstract class EntityBase<Tkey>
{
    public Tkey Id { get; private set; } = default!;

    protected EntityBase(Tkey id)
    {
        Id = id;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;

        if (!IsTypeEquals(obj, this)) return false;

        var entity = obj as EntityBase<Tkey>;

        if (entity is null) return false;

        return EqualityComparer<Tkey>.Default.Equals(Id, entity.Id);
    }

    private static bool IsTypeEquals(object left, object right) 
        => left.GetType() == right.GetType();

    public static bool operator ==(EntityBase<Tkey> left, EntityBase<Tkey> right)
        => IsTypeEquals(left, right) &&
           EqualityComparer<Tkey>.Default.Equals(left.Id, right.Id);

    public static bool operator !=(EntityBase<Tkey> left, EntityBase<Tkey> right) 
        => !(left == right);

    public override int GetHashCode() => HashCode.Combine(GetType(), Id);
}