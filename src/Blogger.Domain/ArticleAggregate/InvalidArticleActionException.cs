using Blogger.Domain.Common.Exceptions;

namespace Blogger.Domain.ArticleAggregate;

public class InvalidArticleActionException(ArticleStatus status)
    : BlogException(string.Format("Invalid action on {0} status", status))
{
}