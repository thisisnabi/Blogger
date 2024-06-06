using Blogger.Application.Articles.GetTaggedArticles;
using Blogger.Domain.ArticleAggregate;
using Blogger.Infrastructure.Persistence.Repositories;
using Blogger.IntegrationTests.Fixtures;
using FluentAssertions;

namespace Blogger.IntegrationTests.Articles;
public class GetTaggedArticlesQueryHandlerTests : IClassFixture<BloggerDbContextFixture>
{
    private readonly BloggerDbContextFixture _fixture;

    public GetTaggedArticlesQueryHandlerTests(BloggerDbContextFixture fixture)
    {
        _fixture = fixture;
    }


    [Fact]
    public async Task Handle_ShouldReturnTaggedArticles_WhenArticlesExist()
    {
        // Arrange
        var tag = Tag.Create("testTag");
        var articleRepository = new ArticleRepository(_fixture.BuildDbContext(Guid.NewGuid().ToString()));
        var sut = new GetTaggedArticlesQueryHandler(articleRepository);
       
        var article_1 = Article.CreateArticle("Title 1", "Test Body", "Test Summary", [Tag.Create("tag1"), Tag.Create("testTag")]);
        var article_2 = Article.CreateArticle("Title 2", "Test Body", "Test Summary", [Tag.Create("tag1"), Tag.Create("tag4")]);

        articleRepository.Add(article_1);
        articleRepository.Add(article_2);

        await articleRepository.SaveChangesAsync(CancellationToken.None);

        var request = new GetTaggedArticlesQuery(tag);

        // Act
        var response = await sut.Handle(request, CancellationToken.None);

        // Assert
        response.Should().NotBeNull();
        response.Should().HaveCount(1);

        response.First().ArticleId.Should().Be(article_1.Id);
        response.First().Tags.Should().Contain(tag);
    }

    [Fact]
    public async Task Handle_ShouldReturnEmpty_WhenNoArticlesExist()
    {
        // Arrange
        var tag = Tag.Create("testTag");
        var articleRepository = new ArticleRepository(_fixture.BuildDbContext(Guid.NewGuid().ToString()));
        var sut = new GetTaggedArticlesQueryHandler(articleRepository);


        var request = new GetTaggedArticlesQuery(tag);

        // Act
        var response = await sut.Handle(request, CancellationToken.None);

        // Assert
        response.Should().NotBeNull();
        response.Should().BeEmpty();
    }

}
