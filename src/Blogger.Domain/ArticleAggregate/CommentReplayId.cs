namespace Blogger.Domain.ArticleAggregate;

public class CommentReplayId : ValueObject<CommentReplayId>
{
    public Guid Value { get; set; }
  
    public override IEnumerable<object> GetEqualityComponenets()
    {
        yield return Value;
    }

    private CommentReplayId(Guid id)
    {
        Value = id;
    }

    public static CommentReplayId CreateUniqueId() => new (Guid.NewGuid());
}
