using Blogger.Domain.Common.Exceptions;

namespace Blogger.Domain.CommentAggregate;

public class UnapprovedCommentException : BlogException
{
    private const string _messages = "Replay is not allowed for unapproved comments.";
    public UnapprovedCommentException() : base(_messages)
    {
    }
}