using Blogger.BuildingBlocks.Domain;


namespace Blogger.Application.Comments.ReplyToComment;
public class NotFoundCommentException : DomainException
{
    private const string _message = "Invalid comment for Reply!";

    public NotFoundCommentException() : base(_message)
    {

    }
}
