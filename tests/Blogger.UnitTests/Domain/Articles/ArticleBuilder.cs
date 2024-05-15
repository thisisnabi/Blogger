using Blogger.Domain.ArticleAggregate;
using Blogger.Domain.CommentAggregate;
using Blogger.UnitTests.Domain.Authors;

namespace Blogger.UnitTests.Domain.Articles;
public class ArticleBuilder
{
    private readonly Defaults _defaults = new();
    public static ArticleBuilder CreateBuilder() => new();

    public ArticleBuilder SetId(ArticleId id)
    {
        _defaults.Id = id;
        return this;
    }
    public ArticleBuilder SetTitle(string title)
    {
        _defaults.Title = title;
        return this;
    }
    public ArticleBuilder SetBody(string body)
    {
        _defaults.Body = body;
        return this;
    }
    public ArticleBuilder SetSummary(string summary)
    {
        _defaults.Summary = summary;
        return this;
    }
    public ArticleBuilder SetPublishedOnUtc(DateTime time)
    {
        _defaults.PublishedOnUtc = time;
        return this;
    }
    public ArticleBuilder SetStatus(ArticleStatus status)
    {
        _defaults.Status = status;
        return this;
    }
    public ArticleBuilder SetReadOn(TimeSpan readOn)
    {
        _defaults.ReadOn = readOn;
        return this;
    }
    public ArticleBuilder SetCommandId(List<CommentId> commandIds)
    {
        _defaults.CommentIds = [];
        commandIds.ForEach(c => _defaults.CommentIds.Add(c));
        return this;
    }
    public ArticleBuilder SetTag(List<Tag> tags)
    {
        _defaults.Tags = [];
        tags.ForEach(t => _defaults.Tags.Add(t));
        return this;
    }
    public Article Build()
    {
        return Article.CreateArticle(_defaults.Title,
                                        _defaults.Body,
                                        _defaults.Summary,
                                        _defaults.Tags);
    }
    public Article BuildDraft()
    {
        return Article.CreateDraft(_defaults.Title,
                                        _defaults.Body,
                                        _defaults.Summary);
    }

    public class Defaults
    {
        private readonly static ArticleId IdDefaultValue = ArticleId.CreateUniqueId("Linq Improvements in .NET 9!");
        public ArticleId Id { get; set; } = IdDefaultValue;

        private readonly static CommentId CommentIdDefaultValue = CommentId.CreateUniqueId();
        public List<CommentId> CommentIds { get; set; } = [CommentIdDefaultValue];

        private readonly static Tag TagDefaultValue = Tag.Create("Programming Languages");
        public List<Tag> Tags { get; set; } = [TagDefaultValue];

        public static Author Author => AuthorBuilder.CreateBuilder().Build();

        public static string TilteDefaultValue => "Linq Improvements in .NET 9!";
        public string Title { get; set; } = TilteDefaultValue;
        public static string BodyDefaultValue => "Just for funny.";
        public string Body { get; set; } = BodyDefaultValue;
        public static string SummaryDefaultValue => "This is my development";
        public string Summary { get; set; } = SummaryDefaultValue;

        public DateTime PublishedOnUtc { get; set; } = DateTime.MinValue;
        public ArticleStatus Status { get; set; } = ArticleStatus.Published;
        public readonly static TimeSpan ReadOnDefaultValue = new(100);
        public TimeSpan? ReadOn { get; set; } = ReadOnDefaultValue;

        public int GetReadOnInMinutes => Convert.ToInt32(ReadOn?.TotalMinutes);
    }
}