namespace Blogger.Domain.CommentAggregate;

public class UnapprovedCommentException : Exception
{
    private const string _messages = "Replay is not allowed for unapproved comments.";
    public UnapprovedCommentException() : base(_messages)
    {
    }
}