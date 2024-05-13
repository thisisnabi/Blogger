using Blogger.Domain.ArticleAggregate;
using FluentAssertions;
namespace Blogger.UnitTests.Domain.Articles;

public class TagTests
{ 
    [Theory]
    [InlineData("Programming ASP.NET Core", "programming-asp.net-core")]
    [InlineData("Programming Languages", "programming-languages")]
    public void Create_ShouldReturnKebabTitle_WhenCreateNewTag(string tagValue, string expectedValue)
    {
        var tag = Tag.Create(tagValue);

        tag.Should().NotBeNull();
        tag.Value.Should().Be(expectedValue);
    }
}