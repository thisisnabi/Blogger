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
        // TODO generate kebab case from the title
        var slug = title;
        return new(slug);
    }
}
