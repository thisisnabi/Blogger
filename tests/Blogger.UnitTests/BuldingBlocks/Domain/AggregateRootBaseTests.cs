using Blogger.Domain.Common;
using FluentAssertions;

using Xunit;

namespace Blogger.UnitTests.BuldingBlocks.Domain;
public class AggregateRootBaseTests
{
    [Fact]
    public void events_should_be_have_item_when_adding_event()
    {
        // arrange
        var aggregateRoot = new ConcreteAggregateRoot(10);

        // act
        aggregateRoot.RaiseCreatedEvent();

        // assert
        aggregateRoot.Events.Should().NotBeEmpty();
        aggregateRoot.Events.Should().HaveCount(1);
    }

   [Fact]
    public void events_should_be_empty_when_create_new_aggregate()
    {
        // arrange
        var aggregateRoot = new ConcreteAggregateRoot(10);
  
        // act
        aggregateRoot.Events.Should().BeEmpty();
    }

    [Fact]
    public void events_should_be_empty_when_call_CleanEvents()
    {
        // arrange
        var aggregateRoot = new ConcreteAggregateRoot(10);
        
        // act
        aggregateRoot.RaiseCreatedEvent();
        aggregateRoot.ClearEvents();

        // act
        aggregateRoot.Events.Should().BeEmpty();
    }

    private class ConcreteAggregateRoot(int id) : AggregateRootBase<int>(id)
    {
        public void RaiseCreatedEvent() => AddEvent(new CreatedRootEvent { });
    }

    private class OtherConcreteAggregateRoot(int id) : AggregateRootBase<int>(id)
    {

    }

    private class CreatedRootEvent : IDomainEvent
    {
        public DateTime OccurredOn => DateTime.UtcNow;
    }

}
