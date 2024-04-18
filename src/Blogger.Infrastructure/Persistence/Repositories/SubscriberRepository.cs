using Blogger.Application.Services;
using Blogger.Domain.SubscriberAggregate;

namespace Blogger.Infrastructure.Persistence.Repositories;
internal class SubscriberRepository : ISubscruiberRepository
{
    private static List<Subscriber> Subscribers = new List<Subscriber>();

    public Task CreateAsync(Subscriber subscriber, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Subscriber> FindById(SubscriberId subscriberId)
    {
        throw new NotImplementedException();
    }

    public Task SavaChangesAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
