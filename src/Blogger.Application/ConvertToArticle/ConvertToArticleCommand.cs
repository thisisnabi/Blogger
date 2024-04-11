namespace Blogger.Application.ConvertToArticle;

public record ConvertToArticleCommand(ArticleId ArticleId)
    : IRequest;