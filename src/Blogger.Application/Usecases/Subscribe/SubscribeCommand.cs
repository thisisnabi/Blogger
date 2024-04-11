using Blogger.Domain.SubscriberAggregate;

namespace Blogger.Application.Subscribe;
public record SubscribeCommand(SubscriberId SubscriberId) : IRequest;
