namespace Blogger.Domain.CommentAggregate;

public class ReplayId : ValueObject<ReplayId>
{
    public Guid Value { get; set; }

    public override IEnumerable<object> GetEqualityComponenets()
    {
        yield return Value;
    }

    private ReplayId(Guid id)
    {
        Value = id;
    }

    public static ReplayId CreateUniqueId() => new(Guid.NewGuid());
}
