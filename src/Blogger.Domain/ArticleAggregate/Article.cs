namespace Blogger.Domain.ArticleAggregate;

public class Article(ArticleId slug) : AggregateRootBase<ArticleId>(slug)
{

    private IList<Comment> _comments = null!;
    public IReadOnlyCollection<Comment> Commnets => _comments.ToImmutableList();

    private IList<Tag> _tags = null!;
    public IReadOnlyCollection<Tag> Tags => _tags.ToImmutableList();

    public Author Author { get; init; }

    public string Title { get; set; }

    public string Body { get; set; }

    public string Summery { get; set; }

    public TimeSpan ReadOn { get; set; }

    public ArticleStatus Status { get; set; }
 
}

public enum ArticleStatus
{ 
    Draft = 1,
    Published = 2
}