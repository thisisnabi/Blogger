using Blogger.Domain.Common.Exceptions;

namespace Blogger.Domain.CommentAggregate;

public class InvalidReplyApprovalLinkException() : BlogException("Invalid Reply approved link.")
{
}
