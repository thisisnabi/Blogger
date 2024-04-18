namespace Blogger.Domain.CommentAggregate;

public class CommentId : ValueObject<CommentId>
{
    public Guid Value { get; init; }

    public override IEnumerable<object> GetEqualityComponenets()
    {
        yield return Value;
    }
    public static CommentId CreateUniqueId() => new CommentId {

        Value = Guid.NewGuid()
    };

    public static CommentId Create(Guid value) => new CommentId
    {
        Value = value
    };
}
