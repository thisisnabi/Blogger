namespace Blogger.BuildingBlocks.Domain;

public interface IAggregateRoot
{
    IReadOnlyCollection<IDomainEvent> Events { get; }

    void ClearEvents();
}
