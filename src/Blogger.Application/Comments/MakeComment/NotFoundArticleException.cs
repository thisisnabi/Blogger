using Blogger.Domain.Common;

namespace Blogger.Application.Comments.MakeComment;
public class NotFoundArticleException : BlogException
{
    private const string _message = "Article not found.";

    public NotFoundArticleException() : base(_message)
    {

    }
}
