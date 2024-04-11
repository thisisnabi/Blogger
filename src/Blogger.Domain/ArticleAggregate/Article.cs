namespace Blogger.Domain.ArticleAggregate;

public class Article(ArticleId slug) : AggregateRootBase<ArticleId>(slug)
{

    private IList<Comment> _comments;
    public IReadOnlyCollection<Comment> Commnets => _comments.ToImmutableList();

    private IList<Tag> _tags;
    public IReadOnlyCollection<Tag> Tags => _tags.ToImmutableList();

    public Author Author { get; private set; }

    public string Title { get; private set; }

    public string Body { get; private set; }

    public string Summery { get; private set; }

    public TimeSpan? ReadOn { get; private set; }

    public ArticleStatus Status { get; private set; }

    public static Article CreateDraft(string title, string body, string summery)
    {
        return new Article(ArticleId.CreateUniqueId(title))
        {
            Author = Author.CreateDefaultAuthor(),
            Body = body,
            Status = ArticleStatus.Draft,
            Summery = summery,
            Title = title,
        };
    }

    public static Article CreateArticle(string title, string body, string summery)
    {
        return new Article(ArticleId.CreateUniqueId(title))
        {
            Author = Author.CreateDefaultAuthor(),
            Body = body,
            Status = ArticleStatus.Published,
            Summery = summery,
            Title = title,
            ReadOn = GetReadOnTimeSpan(body)
        };
    }

    public void AddTags(string[] tags)
    {
        _tags ??= new List<Tag>();

        foreach (var tag in tags)
        {
            _tags.Add(Tag.Create(tag));
        }
    }

    private static TimeSpan GetReadOnTimeSpan(string body)
    {
        // TODO: Calculate base on paragraph and lines of body
        return TimeSpan.FromSeconds(20);
    }

    public void UpdateDraft(string title, string summery, string body)
    {
        Title = title;
        Body = body;
        Summery = summery;
    }

    public void UpdateTags(string[] tags)
    {
        _tags ??= new List<Tag>();
        _tags.Clear();
        AddTags(tags);
    }

    public void ConvertToArticle()
    {
        Status = ArticleStatus.Published;
        ReadOn = GetReadOnTimeSpan(Body);
    }

    public void AddComment(Comment comment)
    {
        _comments ??= new List<Comment>();  
        _comments.Add(comment);
    }
}

public enum ArticleStatus
{
    Draft = 1,
    Published = 2
}