namespace Blogger.BuildingBlocks.Domain;
public abstract class AggregateRoot<TId> : Entity<TId>, IAggregateRoot
    where TId : notnull
{
    public IReadOnlyCollection<IDomainEvent> Events => [.. _events];

    private readonly List<IDomainEvent> _events;

    protected AggregateRoot(TId id) : base(id)
    {
        _events = [];
    }

    public void ClearEvents() => _events.Clear();

    protected void AddEvent<TDomainEvent>(TDomainEvent @event)
        where TDomainEvent : IDomainEvent => _events.Add(@event);
}
