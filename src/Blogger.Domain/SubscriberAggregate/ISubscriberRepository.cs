
namespace Blogger.Domain.SubscriberAggregate;

public interface ISubscriberRepository
{
    Task CreateAsync(Subscriber subscriber, CancellationToken cancellationToken);
    Task<Subscriber> FindById(SubscriberId subscriberId);
    Task<bool> IsExists(SubscriberId subscriberId, CancellationToken cancellationToken);
    Task SavaChangesAsync(CancellationToken cancellationToken);
}
