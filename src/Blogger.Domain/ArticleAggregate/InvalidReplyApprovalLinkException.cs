using Blogger.Domain.Common.Exceptions;

namespace Blogger.Domain.ArticleAggregate;

public class InvalidReplyApprovalLinkException : BlogException
{
    private const string _message = "Invalid Reply approved link.";
    public InvalidReplyApprovalLinkException() : base(_message)
    {
    }
}
