using Blogger.BuildingBlocks.Domain;


namespace Blogger.Application.Comments.ApproveReply;
public class CommentNotFoundException : DomainException
{
    private const string _message = "Comment not found.";

    public CommentNotFoundException() : base(_message)
    {

    }
}
