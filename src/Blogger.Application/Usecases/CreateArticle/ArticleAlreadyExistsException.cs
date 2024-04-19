namespace Blogger.Application.Usecases.CreateArticle;

public sealed class ArticleAlreadyExistsException : Exception
{
    private const string _messages = "Article with ID {0} already exists.";
    public ArticleAlreadyExistsException(string articleId) 
        : base(string.Format(_messages, articleId))
    {
    }
}
