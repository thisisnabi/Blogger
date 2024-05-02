using Blogger.Domain.Common.Exceptions;

namespace Blogger.Application.Subscribers.Subscribe;

public class DuplicateSubscribtionException : BlogException
{
    private const string _messages = "Duplicated registration!";

    public DuplicateSubscribtionException() : base(_messages)
    {

    }
}