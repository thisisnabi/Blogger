using Blogger.Domain.SubscriberAggregate;

namespace Blogger.Application.Usecases.Subscribe;
public record SubscribeCommand(SubscriberId SubscriberId) : IRequest;
