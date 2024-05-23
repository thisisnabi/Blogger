using Blogger.BuildingBlocks.Domain;

using FluentAssertions;

namespace Blogger.UnitTests.BuldingBlocks;
public class AggregateRootBaseTests
{

    [Fact]
    public void entities_of_different_type_should_not_be_equal()
    {
        // Arrange
        var rootA = new ConcreteAggregateRoot(10);
        var rootB = new OtherConcreteAggregateRoot(10);

        // Act & Assert
        (rootA == rootB).Should().BeFalse();
        (rootA != rootB).Should().BeTrue();

        rootB.Equals(rootA).Should().BeFalse();
        rootA.Equals(rootB).Should().BeFalse();

        (rootA.GetHashCode() == rootB.GetHashCode()).Should().BeFalse();
    }

    [Fact]
    public void entities_of_same_type_should_be_equal_when_ids_match()
    {
        // Arrange
        var rootA = new ConcreteAggregateRoot(10);
        var rootB = new ConcreteAggregateRoot(10);

        // Act & Assert
        (rootA == rootB).Should().BeTrue();
        (rootA != rootB).Should().BeFalse();

        rootA.Equals(rootB).Should().BeTrue();
        rootB.Equals(rootA).Should().BeTrue();

        (rootA.GetHashCode() == rootB.GetHashCode()).Should().BeTrue();
    }

    [Fact]
    public void entities_of_same_type_should_not_be_equal_when_ids_different()
    {
        // Arrange
        var rootA = new ConcreteAggregateRoot(10);
        var rootB = new ConcreteAggregateRoot(11);

        // Act & Assert
        (rootA == rootB).Should().BeFalse();
        (rootA != rootB).Should().BeTrue();

        rootA.Equals(rootB).Should().BeFalse();
        rootB.Equals(rootA).Should().BeFalse();

        (rootA.GetHashCode() == rootB.GetHashCode()).Should().BeFalse();
    }

    [Fact]
    public void events_should_be_empty_at_init()
    {
        // Arrange
        var entityA = new ConcreteAggregateRoot(10);

        // Act & Assert
        entityA.Events.Should().BeEmpty();
    }

    [Fact]
    public void events_should_be_have_item_when_adding_event()
    {
        // Arrange
        var entityA = new ConcreteAggregateRoot(10);
        entityA.RaiseCreatedEvent();

        // Act & Assert
        entityA.Events.Should().HaveCount(1);
    }

    [Fact]
    public void events_should_be_empty_after_clean_up()
    {
        // Arrange
        var entityA = new ConcreteAggregateRoot(10);
        entityA.RaiseCreatedEvent();

        // Act
        entityA.ClearEvents();

        // Act & Assert
        entityA.Events.Should().BeEmpty();
    }

    [Fact]
    public void events_should_be_older_than_now()
    {
        // Arrange
        var entityA = new ConcreteAggregateRoot(10);
        entityA.RaiseCreatedEvent();

        // Act & Assert
        entityA.Events.First().OccurredOn.Should().BeBefore(DateTime.UtcNow);
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
