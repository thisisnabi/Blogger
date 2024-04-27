namespace Blogger.Application.Articles.GetTaggedArticles;

public record GetTaggedArticlesQueryResponse(
    ArticleId ArticleId,
    string Title,
    string Summary,
    DateTime PublishedOnUtc,
    int ReadOnMinutes,
    IReadOnlyCollection<Tag> Tags)
{
    public static explicit operator GetTaggedArticlesQueryResponse(Article article)
    => new GetTaggedArticlesQueryResponse(article.Id,
                                   article.Title,
                                   article.Summary,
                                   article.PublishedOnUtc,
                                   article.GetReadOnInMinutes,
                                   article.Tags);
}
