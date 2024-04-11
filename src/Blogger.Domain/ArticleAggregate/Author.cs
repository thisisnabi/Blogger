namespace Blogger.Domain.ArticleAggregate;
public class Author : ValueObject<Author>
{
    public string FullName { get; init; }

    private Author(string fullName)
    {
        FullName = fullName;
    }

    public override IEnumerable<object> GetEqualityComponenets()
    {
        yield return FullName;
    }

    public static Author CreateDefaultAuthor() => new("Nabi Karampour");

    public static Author Create(string fullName) => new(fullName);
}
