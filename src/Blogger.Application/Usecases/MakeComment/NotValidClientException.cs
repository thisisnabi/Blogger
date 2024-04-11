namespace Blogger.Application.Usecases.MakeComment;

public class NotValidClientException : Exception
{
    private const string _messages = "Invalid client id.";

    public NotValidClientException() : base(_messages)
    {

    }
}