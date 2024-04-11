
namespace Blogger.Domain.SubscriberAggregate;

public interface ISubscruiberRepository
{
    Task CreateAsync(Subscriber subscriber, CancellationToken cancellationToken);
    Task<Subscriber> FindById(SubscriberId subscriberId);
    Task SavaChangesAsync(CancellationToken cancellationToken);
}
