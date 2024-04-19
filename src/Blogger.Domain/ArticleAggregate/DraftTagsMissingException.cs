namespace Blogger.Domain.ArticleAggregate;
public class DraftTagsMissingException : Exception
{
    private const string _messages = "Cannot publish draft without tags.";
    public DraftTagsMissingException() : base(_messages)
    {
    }
}
