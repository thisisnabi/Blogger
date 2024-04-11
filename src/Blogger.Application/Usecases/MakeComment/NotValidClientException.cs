namespace Blogger.Application.MakeComment;

public class NotValidClientException : Exception
{
    private const string _messages = "Invalid client id.";

    public NotValidClientException() : base(_messages)
    {
        
    }
}