using Blogger.BuildingBlocks.Domain;

using FluentAssertions;

namespace Blogger.UnitTests.BuldingBlocks;
public class EntityBaseTests
{
    [Fact]
    public void entities_of_different_type_should_not_be_equal()
    {
        // Arrange
        var id = Guid.NewGuid();
        var entityA = new ConcreteEntity(id);
        var entityB = new OtherConcreteEntity(id);

        // Act & Assert
        (entityA == entityB).Should().BeFalse();
        (entityA != entityB).Should().BeTrue();

        entityB.Equals(entityA).Should().BeFalse();
        entityA.Equals(entityB).Should().BeFalse();

        (entityA.GetHashCode() == entityB.GetHashCode()).Should().BeFalse();
    }

    [Fact]
    public void entities_of_same_type_should_be_equal_when_ids_match()
    {
        // Arrange
        var id = Guid.NewGuid();
        var entityA = new ConcreteEntity(id);
        var entityB = new ConcreteEntity(id);

        // Act & Assert
        (entityA == entityB).Should().BeTrue();
        (entityA != entityB).Should().BeFalse();

        entityA.Equals(entityB).Should().BeTrue();
        entityB.Equals(entityA).Should().BeTrue();

        (entityA.GetHashCode() == entityB.GetHashCode()).Should().BeTrue();
    }

    [Fact]
    public void entities_of_same_type_should_not_be_equal_when_ids_different()
    {
        // Arrange
        var entityA = new ConcreteEntity(Guid.NewGuid());
        var entityB = new ConcreteEntity(Guid.NewGuid());

        // Act & Assert
        (entityA == entityB).Should().BeFalse();
        (entityA != entityB).Should().BeTrue();

        entityA.Equals(entityB).Should().BeFalse();
        entityB.Equals(entityA).Should().BeFalse();

        (entityA.GetHashCode() == entityB.GetHashCode()).Should().BeFalse();
    }

    private class ConcreteEntity(Guid id) : EntityBase<Guid>(id) { }
    private class OtherConcreteEntity(Guid id) : EntityBase<Guid>(id) { }
}