using Blogger.Domain.Common;

namespace Blogger.Application.Comments.ApproveComment;

public class InvalidCommentApprovalLinkException : BlogException
{
    private const string _message = "Invalid comment approved link.";
    public InvalidCommentApprovalLinkException() : base(_message)
    {
    }
}
