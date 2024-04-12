namespace Blogger.Application.Usecases.GetArticle;

public record GetArticleQueryResponse(
    ArticleId ArticleId,
    string Title, 
    string Body,
    string Summery,
    int ReadOnMinutes,
    Author Author,
    DateTime PublishedOnUtc,
    IReadOnlyCollection<Tag> Tags);
