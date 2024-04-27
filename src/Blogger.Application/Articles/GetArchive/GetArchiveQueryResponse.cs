namespace Blogger.Application.Articles.GetArchive;

public record GetArchiveQueryResponse(int Year, int Month, IReadOnlyList<ArticleOnArchive> Articles);

public record ArticleOnArchive(ArticleId ArticleId, string Title, int Day)
{
    public static explicit operator ArticleOnArchive(Article article)
        => new ArticleOnArchive(article.Id, article.Title, article.PublishedOnUtc.Day);
}
