using Blogger.Domain.CommentAggregate;

namespace Blogger.Domain.ArticleAggregate;

public class Article : AggregateRootBase<ArticleId>
{

    public Article(ArticleId slug) : base(slug)
    {
        _tags = [];
        _commentIds = [];
    }

    private Article() : this(null!) { }
     
    private readonly List<CommentId> _commentIds = null!;
    public IReadOnlyCollection<CommentId> CommentIds => [.._commentIds];

    private readonly List<Tag> _tags = null!;
    public IReadOnlyCollection<Tag> Tags => [.. _tags];

    public Author Author { get; private set; } = null!;

    public string Title { get; private set; } = null!;

    public string Body { get; private set; } = null!;

    public string Summary { get; private set; } = null!;

    public DateTime PublishedOnUtc { get; set; } = DateTime.MinValue;

    public ArticleStatus Status { get; private set; }

    public TimeSpan? ReadOn { get; private set; }

    public int GetReadOnInMinutes => Convert.ToInt32(ReadOn?.TotalMinutes);

    public static Article CreateDraft(string title, string body, string summary)
    {
        return new Article(ArticleId.CreateUniqueId(title))
        {
            Author = Author.CreateDefaultAuthor(),
            Body = body,
            Status = ArticleStatus.Draft,
            Summary = summary,
            Title = title,
        };
    }

    public static Article CreateArticle(string title, string body, string summary, IReadOnlyList<Tag> tags)
    {
        var article = CreateDraft(title, body, summary); 

        article.AddTags(tags);
        article.Publish();

        return article;
    }

    public void AddTags(IReadOnlyList<Tag> tags)
    {
        foreach (var tag in tags)
        {
            _tags.Add(tag);
        }
    }

    private static TimeSpan GetReadOnTimeSpan(string body)
    {
        if (string.IsNullOrWhiteSpace(body))
        {
            return TimeSpan.Zero;
        }

        var words = body.Split([ ' ', '\t', '\n', '\r' ], StringSplitOptions.RemoveEmptyEntries).Length;
        var readingTimeMinutes = words / 200.0;
        return TimeSpan.FromMinutes(readingTimeMinutes);
    }

    public void UpdateDraft(string title, string summary, string body)
    {
        Title = title;
        Body = body;
        Summary = summary;
    }

    public void UpdateTags(IReadOnlyList<Tag> tags)
    {
        if (_tags is not null)
            _tags.Clear();

        AddTags(tags);
    }

    public void Publish()
    { 
        if (_tags.Count == 0)
        {
            throw new DraftTagsMissingException();
        }

        Status = ArticleStatus.Published;
        ReadOn = GetReadOnTimeSpan(Body);
        PublishedOnUtc = DateTime.UtcNow;
    }

    public void Remove()
    {
        Status = ArticleStatus.Deleted;
    }
}

