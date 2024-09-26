﻿
namespace Blogger.Domain.SubscriberAggregate;

public interface ISubscriberRepository:IRepository<Subscriber>
{
    Task CreateAsync(Subscriber subscriber, CancellationToken cancellationToken);
    Task<Subscriber?> FindByIdAsync(SubscriberId subscriberId);
    Task<bool> IsExistsAsync(SubscriberId subscriberId, CancellationToken cancellationToken);
    Task SavaChangesAsync(CancellationToken cancellationToken);
}
