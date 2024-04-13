using Humanizer;

namespace Blogger.Domain.ArticleAggregate;
public class Tag : ValueObject<Tag>
{
    public string Value { get; init; }

    private Tag(string value)
    {
        Value = value;
    }

    public override IEnumerable<object> GetEqualityComponenets()
    {
        yield return Value;
    }

    public static Tag Create(string tagValue)
    {
        var value = tagValue.Kebaberize();
        return new(value);
    }
}
