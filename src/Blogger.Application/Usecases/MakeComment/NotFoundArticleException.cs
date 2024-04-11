namespace Blogger.Application.Usecases.MakeComment;
public class NotFoundArticleException : Exception
{
    private const string _message = "Invalid article for commenting!";

    public NotFoundArticleException() : base(_message)
    {

    }
}
