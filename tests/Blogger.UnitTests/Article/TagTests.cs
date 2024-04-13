using Blogger.Domain.ArticleAggregate;

namespace Blogger.UnitTests.Article;

public class TagTests
{
    [Theory]
    [InlineData("test", "test")]
    [InlineData("Test", "test")]
    [InlineData("testValue", "test-value")]
    [InlineData("test Value 1", "test-value-1")]
    [InlineData("عنوان تستی", "عنوان-تستی")]
    public void Tag_Should_Be_Kebab_Case(string actual, string expected)
    {
        var tag = Tag.Create(actual);

        tag.Value.Should().Be(expected);
    }
}
