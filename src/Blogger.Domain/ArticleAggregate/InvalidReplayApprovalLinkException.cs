using Blogger.Domain.Common.Exceptions;

namespace Blogger.Domain.ArticleAggregate;

public class InvalidReplayApprovalLinkException : BlogException
{
    private const string _message = "Invalid replay approved link.";
    public InvalidReplayApprovalLinkException() : base(_message)
    {
    }
}
