namespace Blogger.Domain.ArticleAggregate;

public class InvalidArticleActionException : BlogException
{
    public InvalidArticleActionException(ArticleStatus status)
        : base(string.Format("Invalid action on {0} status", status))
    {

    }
}