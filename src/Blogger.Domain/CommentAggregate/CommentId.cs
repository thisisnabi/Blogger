namespace Blogger.Domain.CommentAggregate;

public class CommentId : ValueObject<CommentId>
{
    public Guid Value { get; set; }

    public override IEnumerable<object> GetEqualityComponenets()
    {
        yield return Value;
    }

    private CommentId(Guid id)
    {
        Value = id;
    }

    public static CommentId CreateUniqueId() => new(Guid.NewGuid());

    public static CommentId Create(Guid value) => new(value);
}
