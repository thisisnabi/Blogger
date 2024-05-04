using Blogger.Domain.Common.Exceptions;

namespace Blogger.Application.Comments.ReplyToComment;
public class NotFoundCommentException : BlogException
{
    private const string _message = "Invalid comment for Reply!";

    public NotFoundCommentException() : base(_message)
    {

    }
}
