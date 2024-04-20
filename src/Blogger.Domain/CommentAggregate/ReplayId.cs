namespace Blogger.Domain.CommentAggregate;

public class ReplayId : ValueObject<ReplayId>
{
    public Guid Value { get; init; }

    public override IEnumerable<object> GetEqualityComponenets()
    {
        yield return Value;
    }
     
    public static ReplayId CreateUniqueId() => new ReplayId
    {
        Value = Guid.NewGuid()
    };

    public static ReplayId Create(Guid value) => new ReplayId
    {
        Value = value
    };

    public override string ToString()
    {
        return Value.ToString();
    }
}
