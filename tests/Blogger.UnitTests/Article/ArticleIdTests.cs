using Blogger.Domain.ArticleAggregate;

namespace Blogger.UnitTests.Article;

public class ArticleIdTests
{
    [Theory]
    [InlineData("test","test")]
    [InlineData("Test","test")]
    [InlineData("testValue","test-value")]
    [InlineData("test Value 1","test-value-1")]
    [InlineData("عنوان تستی","عنوان-تستی")]
    public void ArticleId_Should_Be_Kebab_Case(string actual,string expected)
    {
        var articleId = ArticleId.CreateUniqueId(actual);

        articleId.Slug.Should().Be(expected);
    }
}
