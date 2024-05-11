namespace Blogger.Domain.CommentAggregate;

public class CommentId : ValueObject<CommentId>
{
    public Guid Value { get; init; }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    public static CommentId CreateUniqueId() => Create(
        Guid.NewGuid()
    );

    public static CommentId Create(Guid value) => new CommentId
    {
        Value = value
    };

    public override string ToString()
    {
        return Value.ToString();
    }
}
