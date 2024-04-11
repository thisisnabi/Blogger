namespace Blogger.Domain.UserAggregate;

public class UserId : ValueObject<UserId>
{
    public Guid Value { get; set; }

    public override IEnumerable<object> GetEqualityComponenets()
    {
        yield return Value;
    }

    private UserId(Guid id)
    {
        Value = id;
    }

    public static UserId CreateUniqueId() => new(Guid.NewGuid());

}
