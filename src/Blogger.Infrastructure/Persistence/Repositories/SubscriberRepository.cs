using Blogger.Domain.SubscriberAggregate;

namespace Blogger.Infrastructure.Persistence.Repositories;
internal class SubscriberRepository(BloggerDbContext bloggerDbContext) : ISubscruiberRepository
{

    public async Task CreateAsync(Subscriber subscriber, CancellationToken cancellationToken)
    {
        await bloggerDbContext.Subscribers.AddAsync(subscriber, cancellationToken);
    }

    public async Task<Subscriber> FindById(SubscriberId subscriberId)
    {
        var subscriber = await bloggerDbContext.Subscribers.FindAsync(subscriberId);
        return subscriber;
    }

    public async Task SavaChangesAsync(CancellationToken cancellationToken)
    {
        await bloggerDbContext.SaveChangesAsync(cancellationToken);
    }
}
