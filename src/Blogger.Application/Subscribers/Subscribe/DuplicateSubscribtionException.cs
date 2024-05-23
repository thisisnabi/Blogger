using Blogger.BuildingBlocks.Domain;


namespace Blogger.Application.Subscribers.Subscribe;

public class DuplicateSubscribtionException : DomainException
{
    private const string _messages = "Duplicated registration!";

    public DuplicateSubscribtionException() : base(_messages)
    {

    }
}