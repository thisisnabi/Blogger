namespace Blogger.Domain.ArticleAggregate;

public class Article(ArticleId slug) : AggregateRootBase<ArticleId>(slug)
{

    private IList<Comment> _comments = null!;
    public IReadOnlyCollection<Comment> Commnets => _comments.ToImmutableList();

    private IList<Tag> _tags = null!;
    public IReadOnlyCollection<Tag> Tags => _tags.ToImmutableList();

    public Author Author { get; init; }

     


}
