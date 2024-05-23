namespace Blogger.Domain.CommentAggregate;

public class UnapprovedCommentException : DomainException
{
    private const string _messages = "Reply is not allowed for unapproved comments.";
    public UnapprovedCommentException() : base(_messages)
    {
    }
}