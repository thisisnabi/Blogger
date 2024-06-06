using Blogger.BuildingBlocks.Domain;

namespace Blogger.Application.Articles.CreateArticle;

public sealed class ArticleAlreadyExistsException : DomainException
{
    private const string _messages = "Article with Title `{0}` already exists.";
    public ArticleAlreadyExistsException(string articleId)
        : base(string.Format(_messages, articleId))
    {
    }
}
