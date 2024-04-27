namespace Blogger.Application.Subscribers.Subscribe;

public class DuplicateSubscribtionException : Exception
{
    private const string _messages = "Duplicated registration!";

    public DuplicateSubscribtionException() : base(_messages)
    {

    }
}