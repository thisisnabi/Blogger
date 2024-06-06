using Blogger.Application.Articles.GetArchive;
using Blogger.Domain.ArticleAggregate;
using Blogger.Infrastructure.Persistence.Repositories;
using Blogger.IntegrationTests.Fixtures;

using FluentAssertions;

namespace Blogger.IntegrationTests.Articles;
public class GetArchiveQueryHandlerTests : IClassFixture<BloggerDbContextFixture>
{
    private readonly BloggerDbContextFixture _fixture;

    public GetArchiveQueryHandlerTests(BloggerDbContextFixture fixture)
    {
        _fixture = fixture;
    }


    [Fact]
    public async Task Handle_ShouldReturnArchive_WhenArticlesExist()
    {
        // Arrange
        var articleRepository = new ArticleRepository(_fixture.BuildDbContext(Guid.NewGuid().ToString()));
        var sut = new GetArchiveQueryHandler(articleRepository);

        var article_1 = Article.CreateArticle("Title 1", "Test Body", "Test Summary", [Tag.Create("tag1"), Tag.Create("tag2")]);
        var article_2 = Article.CreateArticle("Title 2", "Test Body", "Test Summary", [Tag.Create("tag1"), Tag.Create("tag2")]);

        articleRepository.Add(article_1);
        articleRepository.Add(article_2);
        await articleRepository.SaveChangesAsync(CancellationToken.None);

        // Act
        var response = await sut.Handle(new GetArchiveQuery(), CancellationToken.None);

        // Assert
        response.Should().NotBeNull();
        response.Should().HaveCount(1);

        var archiveResponse = response.First();
        archiveResponse.Articles.Should().HaveCount(2);
        archiveResponse.Year.Should().Be(DateTime.UtcNow.Year);
        archiveResponse.Month.Should().Be(DateTime.UtcNow.Month);
    }

    [Fact]
    public async Task Handle_ShouldReturnEmpty_WhenNoArticlesExist()
    {
        // Arrange
        var articleRepository = new ArticleRepository(_fixture.BuildDbContext(Guid.NewGuid().ToString()));
        var sut = new GetArchiveQueryHandler(articleRepository);

        // Act
        var response = await sut.Handle(new GetArchiveQuery(), CancellationToken.None);

        // Assert
        response.Should().NotBeNull();
        response.Should().BeEmpty();
    }



}
