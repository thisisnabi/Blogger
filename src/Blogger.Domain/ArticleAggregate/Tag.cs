using Humanizer;

namespace Blogger.Domain.ArticleAggregate;
public class Tag : ValueObject<Tag>
{
    public string Value { get; init; } = null!;

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static Tag Create(string tagValue)
    {
        return new Tag
        {
            Value = tagValue.Kebaberize()
        };
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}
