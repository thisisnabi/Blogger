using Blogger.Application.Articles.GetPopularTags;
using Blogger.Domain.ArticleAggregate;
using Blogger.Infrastructure.Persistence.Repositories;
using Blogger.IntegrationTests.Fixtures;

using FluentAssertions;

namespace Blogger.IntegrationTests.Articles;
public class GetPopularTagsQueryHandlerTests : IClassFixture<BloggerDbContextFixture>
{
    private readonly BloggerDbContextFixture _fixture;

    public GetPopularTagsQueryHandlerTests(BloggerDbContextFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task Handle_ShouldReturnPopularTags_WhenTagsExist()
    {
        // Arrange
        var articleRepository = new ArticleRepository(_fixture.BuildDbContext(Guid.NewGuid().ToString()));
        var sut = new GetPopularTagsQueryHandler(articleRepository);

        var article_1 = Article.CreateArticle("Title 1", "Test Body", "Test Summary", [Tag.Create("tag1"), Tag.Create("tag2")]);
        var article_2 = Article.CreateArticle("Title 2", "Test Body", "Test Summary", [Tag.Create("tag1"), Tag.Create("tag4")]);
        var article_3 = Article.CreateArticle("Title 3", "Test Body", "Test Summary", [Tag.Create("tag4"), Tag.Create("tag2")]);
        var article_4 = Article.CreateArticle("Title 4", "Test Body", "Test Summary", [Tag.Create("tag4"), Tag.Create("tag2")]);
        var article_5 = Article.CreateArticle("Title 5", "Test Body", "Test Summary", [Tag.Create("tag2"), Tag.Create("tag3")]);

        articleRepository.Add(article_1);
        articleRepository.Add(article_2);
        articleRepository.Add(article_3);
        articleRepository.Add(article_4);
        articleRepository.Add(article_5);

        await articleRepository.SaveChangesAsync(CancellationToken.None);


        var request = new GetPopularTagsQuery(2);

        // Act
        var response = await sut.Handle(request, CancellationToken.None);

        // Assert
        response.Should().NotBeNull();
        response.Should().HaveCount(2);

        response[0].Tag.Value.Should().Be("tag2");
        response[1].Tag.Value.Should().Be("tag4");
    }

    [Fact]
    public async Task Handle_ShouldReturnEmpty_WhenNoTagsExist()
    {
        // Arrange
        var articleRepository = new ArticleRepository(_fixture.BuildDbContext(Guid.NewGuid().ToString()));
        var sut = new GetPopularTagsQueryHandler(articleRepository);


        var request = new GetPopularTagsQuery(2);

        // Act
        var response = await sut.Handle(request, CancellationToken.None);

        // Assert
        response.Should().NotBeNull();
        response.Should().BeEmpty();
    }
}
