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
        var entity = obj as EntityBase<Tkey>;

        if (entity is null) return false;

        return  IsTypeEquals(entity, this) &&
                EqualityComparer<Tkey>.Default.Equals(Id, entity.Id);
    }

    private static bool IsTypeEquals(EntityBase<Tkey> left, EntityBase<Tkey> right) 
        => left.GetType() == right.GetType();

    public static bool operator ==(EntityBase<Tkey> left, EntityBase<Tkey> right)
    {
        return  IsTypeEquals(left, right) &&
                EqualityComparer<Tkey>.Default.Equals(left.Id, right.Id);
    }

    public static bool operator !=(EntityBase<Tkey> left, EntityBase<Tkey> right) 
        => !(left == right);

    public override int GetHashCode() => HashCode.Combine(GetType(), Id);
}