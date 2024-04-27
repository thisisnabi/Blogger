namespace Blogger.Application.Articles.GetArticle;

public record GetArticleQueryResponse(
    ArticleId ArticleId,
    string Title,
    string Body,
    string Summary,
    int ReadOnMinutes,
    Author Author,
    DateTime PublishedOnUtc,
    IReadOnlyCollection<Tag> Tags)
{

    public static explicit operator GetArticleQueryResponse(Article article)
        => new GetArticleQueryResponse(article.Id,
                                       article.Title,
                                       article.Body,
                                       article.Summary,
                                       article.GetReadOnInMinutes,
                                       article.Author,
                                       article.PublishedOnUtc,
                                       article.Tags);

}
