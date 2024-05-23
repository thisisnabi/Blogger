using Blogger.Domain.Common.Exceptions;

namespace Blogger.Application.Comments.MakeComment;
public class NotFoundArticleException : DomainException
{
    private const string _message = "Article not found.";

    public NotFoundArticleException() : base(_message)
    {

    }
}
