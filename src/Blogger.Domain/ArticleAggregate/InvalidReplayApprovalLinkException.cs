namespace Blogger.Domain.ArticleAggregate;

public class InvalidReplayApprovalLinkException : Exception
{
    private const string _message = "Invalid replay approved link.";
    public InvalidReplayApprovalLinkException() : base(_message)
    {
    }
}
