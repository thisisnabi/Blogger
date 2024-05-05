using Blogger.Domain.ArticleAggregate;
using Blogger.Domain.CommentAggregate;
using Blogger.Domain.Common;
using Blogger.Domain.SubscriberAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Blogger.Infrastructure.Persistence;
public class BloggerDbContext : DbContext
{
    private readonly IPublisher publisher;

    public BloggerDbContext(DbContextOptions<BloggerDbContext> dbContextOptions, IPublisher publisher)
            : base(dbContextOptions)
    {
        this.publisher = publisher;
    }

    public DbSet<Article> Articles => Set<Article>();
    public DbSet<Comment> Comments => Set<Comment>();
    public DbSet<Subscriber> Subscribers => Set<Subscriber>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(BloggerDbContextSchema.DefualtSchema);

        var infrastructureAssembly = typeof(IAssemblyMarker).Assembly;
        modelBuilder.ApplyConfigurationsFromAssembly(infrastructureAssembly); 
    }
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await PublishDomainEventsAsync();
        return await base.SaveChangesAsync(cancellationToken);
    }
    private async Task PublishDomainEventsAsync()
    {
        var entitiesWithEvents = ChangeTracker.Entries<IAggregateRoot>()
            .Select(e => e.Entity)
            .Where(e => e.Events.Any())
            .ToArray();

        foreach (var entity in entitiesWithEvents)
        {
            var events = entity.Events.ToArray();
            entity.ClearEvents();
            foreach (var domainEvent in events)
            {
                await publisher.Publish(domainEvent);
            }
        }
    }
}
