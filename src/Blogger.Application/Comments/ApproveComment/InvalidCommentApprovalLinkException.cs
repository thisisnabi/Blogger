namespace Blogger.Application.Comments.ApproveComment;

public class InvalidCommentApprovalLinkException : Exception
{
    private const string _message = "Invalid comment approved link.";
    public InvalidCommentApprovalLinkException() : base(_message)
    {
    }
}
