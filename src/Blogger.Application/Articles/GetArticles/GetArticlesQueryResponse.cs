namespace Blogger.Application.Articles.GetArticles;

public record GetArticlesQueryResponse(
    ArticleId ArticleId,
    string Title,
    string Summary,
    DateTime PublishedOnUtc,
    int ReadOnMinutes,
    IReadOnlyCollection<Tag> Tags)
{
    public static explicit operator GetArticlesQueryResponse(Article article)
    => new GetArticlesQueryResponse(article.Id,
                                   article.Title,
                                   article.Summary,
                                   article.PublishedOnUtc,
                                   article.GetReadOnInMinutes,
                                   article.Tags);
}
