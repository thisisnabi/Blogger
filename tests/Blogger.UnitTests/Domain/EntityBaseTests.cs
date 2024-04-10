using Blogger.Domain.Common;
using FluentAssertions;

namespace Blogger.UnitTests.Domain;
public class EntityBaseTests
{
    [Fact]
    public void entities_of_different_type_should_not_be_equal()
    {
        var id = Guid.NewGuid();
        var testA = new TestClassA(id);
        var testB = new TestClassB(id);

        (testA == testB).Should().BeFalse();
        testB.Equals(testA).Should().BeFalse();
        testA.Equals(testB).Should().BeFalse();

        (testA.GetHashCode() == testB.GetHashCode()).Should().BeFalse();
    }

    [Fact]
    public void entities_of_same_type_should_be_equal_when_ids_match()
    {
        var id = Guid.NewGuid();
        var entityA = new TestClassA(id);
        var entityB = new TestClassA(id);

        (entityA == entityB).Should().BeTrue();
        entityA.Equals(entityB).Should().BeTrue();
        entityB.Equals(entityA).Should().BeTrue();

        (entityA.GetHashCode() == entityB.GetHashCode()).Should().BeTrue();
    }

    [Fact]
    public void entities_of_same_type_should_not_be_equal_when_ids_different()
    {
        var entityA = new TestClassA(Guid.NewGuid());
        var entityB = new TestClassA(Guid.NewGuid());

        (entityA == entityB).Should().BeFalse();
        entityA.Equals(entityB).Should().BeFalse();
        entityB.Equals(entityA).Should().BeFalse();

        (entityA.GetHashCode() == entityB.GetHashCode()).Should().BeFalse();
    }

    private class TestClassA(Guid id) : EntityBase<Guid>(id) { }
    private class TestClassB(Guid id) : EntityBase<Guid>(id) { }
}
