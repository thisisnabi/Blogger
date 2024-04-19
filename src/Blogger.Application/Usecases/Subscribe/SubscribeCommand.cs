namespace Blogger.Application.Usecases.Subscribe;
public record SubscribeCommand(SubscriberId SubscriberId) : IRequest;
