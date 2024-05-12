using Blogger.Domain.Common.Exceptions;

namespace Blogger.Domain.CommentAggregate;

public class UnapprovedCommentException() : BlogException("Reply is not allowed for unapproved comments.")
{
}