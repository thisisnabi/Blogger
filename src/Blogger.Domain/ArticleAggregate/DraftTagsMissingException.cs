namespace Blogger.Domain.ArticleAggregate;

public class DraftTagsMissingException : DomainException
{
    private const string _messages = "Cannot publish draft without tags.";
    public DraftTagsMissingException() : base(_messages)
    {
    }
}
