using Blogger.Domain.Common.Exceptions;

namespace Blogger.Application.Comments.ReplayToComment;
public class NotFoundCommentException : BlogException
{
    private const string _message = "Invalid comment for replay!";

    public NotFoundCommentException() : base(_message)
    {

    }
}
