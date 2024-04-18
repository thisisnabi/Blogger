using Blogger.Application.Services;
using Blogger.Domain.SubscriberAggregate;

namespace Blogger.Infrastructure.Persistence.Repositories;
internal class SubscriberRepository : ISubscriberService
{
    private static List<Subscriber> Subscribers = new List<Subscriber>();

    public Task<bool> IsDuplicated(SubscriberId subscriberId, CancellationToken cancellationToken)
    {
        return Task.FromResult(Subscribers.FirstOrDefault(x => x.Id == subscriberId) is not null);
    }
}
