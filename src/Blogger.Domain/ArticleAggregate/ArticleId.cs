using Humanizer;

namespace Blogger.Domain.ArticleAggregate;

public sealed class ArticleId : ValueObject<ArticleId>
{
    public required string Slug { get; init; }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Slug;
    }
  
    public static ArticleId CreateUniqueId(string title) 
        => Create(title.Kebaberize());

    public static ArticleId Create(string value) 
        => new ArticleId{  Slug = value };

    public override string ToString() => Slug;
}
