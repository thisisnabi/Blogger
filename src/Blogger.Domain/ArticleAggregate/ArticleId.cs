using Humanizer;
namespace Blogger.Domain.ArticleAggregate;

public class ArticleId : ValueObject<ArticleId>
{
    public string Slug { get; set; }

    public override IEnumerable<object> GetEqualityComponenets()
    {
        yield return Slug;
    }

    private ArticleId(string slug)
    {
        Slug = slug;
    }

    public static ArticleId CreateUniqueId(string title)
    {
        var slug = title.Kebaberize();
        return new(slug);
    }
}
