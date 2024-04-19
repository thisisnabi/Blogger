namespace Blogger.Application.Usecases.CreateArticle;

public sealed class DraftAlreadyExistsException : Exception
{
    private const string _messages = "Draft with Title {0} already exists.";
    public DraftAlreadyExistsException(string articleId) 
        : base(string.Format(_messages, articleId))
    {
    }
}
