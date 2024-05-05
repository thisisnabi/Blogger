using MediatR;

namespace Blogger.Domain.Common;
public interface IDomainEvent : INotification
{
    DateTime OccurredOn { get; }
}
