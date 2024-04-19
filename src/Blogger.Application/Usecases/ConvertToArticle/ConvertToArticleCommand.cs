namespace Blogger.Application.Usecases.ConvertToArticle;

public record ConvertToArticleCommand(ArticleId DraftId)
    : IRequest;