namespace Blogger.Application.Usecases.MakeComment;
public class NotFoundArticleException : Exception
{
    private const string _message = "Article not found.";

    public NotFoundArticleException() : base(_message)
    {

    }
}
