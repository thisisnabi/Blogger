

using System.Security.Cryptography;

using Blogger.BuildingBlocks.Domain;
using MediatR;

namespace Blogger.Infrastructure.Persistence;

public static class MediatorExtension
{
    public static async Task DispatcherEventAsync(this IMediator mediator, BloggerDbContext bloggerDbContext)
    {
        var domainEntities = bloggerDbContext.ChangeTracker
            .Entries<AggregateRoot<string>>()
            .Where(x => x.Entity.Events != null && x.Entity.Events.Count != 0);

        var domainEvents = domainEntities
            .SelectMany(x => x.Entity.Events)
            .ToList();

        domainEntities.ToList()
            .ForEach(entity => entity.Entity.ClearEvents());

        foreach (var domainEvent in domainEvents)
            await mediator.Publish(domainEvent);
    }
}
