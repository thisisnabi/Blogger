using Humanizer;
namespace Blogger.Domain.ArticleAggregate;

public class ArticleId : ValueObject<ArticleId>
{
    public string Value { get; set; }

    public override IEnumerable<object> GetEqualityComponenets()
    {
        yield return Value;
    }

    private ArticleId(string slug)
    {
        Value = slug;
    }

    public static ArticleId CreateUniqueId(string title)
    {
        var slug = title.Kebaberize();
        return new(slug);
    }
}
