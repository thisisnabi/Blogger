namespace Blogger.Application.Subscribers.Subscribe;
public record SubscribeCommand(SubscriberId SubscriberId) : IRequest;
