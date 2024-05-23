using Blogger.Domain.Common.Exceptions;

namespace Blogger.Domain.ArticleAggregate;

public class InvalidArticleActionException : DomainException
{
    public InvalidArticleActionException(ArticleStatus status)
        : base(string.Format("Invalid action on {0} status", status))
    {

    }
}