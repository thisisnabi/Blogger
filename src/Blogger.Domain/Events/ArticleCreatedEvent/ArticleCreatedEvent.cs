using Blogger.Domain.ArticleAggregate;

namespace Blogger.Domain.Events.ArticleCreated;
public class ArticleCreatedEvent : IDomainEvent
{
    DateTime IDomainEvent.OccurredOn => DateTime.UtcNow;
    public Article Article { get; set; }
    public string ArticleLink { get; set; }
}
