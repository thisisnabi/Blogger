namespace Blogger.Application.Usecases.Subscribe;

public class DuplicateSubscribtionException : Exception
{
    private const string _messages = "Duplicated registration!";

    public DuplicateSubscribtionException() : base(_messages)
    {

    }
}