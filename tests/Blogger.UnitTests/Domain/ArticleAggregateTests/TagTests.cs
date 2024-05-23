using Blogger.Domain.ArticleAggregate;

using FluentAssertions;

namespace Blogger.UnitTests.Domain.ArticleAggregateTests;

public class TagTests
{
    [Fact]
    public void Create_ShouldReturnTagWithKebabCaseValue()
    {
        // Arrange
        var tagValue = "Test Value";

        // Act
        var tag = Tag.Create(tagValue);

        // Assert
        tag.Value.Should().Be("test-value");
    }

    [Fact]
    public void ToString_ShouldReturnValue()
    {
        // Arrange
        var tagValue = "Test Value";
        var tag = Tag.Create(tagValue);

        // Act
        var result = tag.ToString();

        // Assert
        result.Should().Be("test-value");
    }

    [Fact]
    public void TagsWithSameValue_ShouldBeEqual()
    {
        // Arrange
        var tagValue1 = "Test Value";
        var tagValue2 = "Test Value";

        // Act
        var tag1 = Tag.Create(tagValue1);
        var tag2 = Tag.Create(tagValue2);

        // Assert
        tag1.Should().Be(tag2);
    }

    [Fact]
    public void TagsWithDifferentValues_ShouldNotBeEqual()
    {
        // Arrange
        var tagValue1 = "Test Value 1";
        var tagValue2 = "Test Value 2";

        // Act
        var tag1 = Tag.Create(tagValue1);
        var tag2 = Tag.Create(tagValue2);

        // Assert
        tag1.Should().NotBe(tag2);
    }
}
