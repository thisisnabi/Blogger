namespace Blogger.BuildingBlocks.Domain;
public interface IDomainEvent
{
    DateTime OccurredOn { get; }
}
