namespace Blogger.Infrastructure.Persistence.Repositories;
internal class SubscriberRepository(BloggerDbContext bloggerDbContext) : ISubscriberRepository
{

    public async Task CreateAsync(Subscriber subscriber, CancellationToken cancellationToken)
    {
        await bloggerDbContext.Subscribers.AddAsync(subscriber, cancellationToken);
    }

    public async Task<Subscriber?> FindByIdAsync(SubscriberId subscriberId)
    {
        var subscriber = await bloggerDbContext.Subscribers.FindAsync(subscriberId);
        return subscriber;
    }
    public Task<bool> IsExistsAsync(SubscriberId subscriberId, CancellationToken cancellationToken)
    {
        return bloggerDbContext.Subscribers.AnyAsync(s => s.Id.Equals(subscriberId), cancellationToken);
    }
    public async Task SavaChangesAsync(CancellationToken cancellationToken)
    {
        await bloggerDbContext.SaveChangesAsync(cancellationToken);
    }
}
