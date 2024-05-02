using Blogger.Domain.Common.Exceptions;

namespace Blogger.Domain.ArticleAggregate;
public class DraftTagsMissingException : BlogException
{
    private const string _messages = "Cannot publish draft without tags.";
    public DraftTagsMissingException() : base(_messages)
    {
    }
}
