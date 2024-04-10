namespace Blogger.Domain.Common;
public interface IDomainEvent
{
    DateTime OccurredOn { get; }
}
