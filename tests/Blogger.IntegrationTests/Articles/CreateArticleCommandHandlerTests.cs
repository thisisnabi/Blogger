using Blogger.Application.Articles.CreateArticle;
using Blogger.Domain.ArticleAggregate;
using Blogger.Infrastructure.Persistence.Repositories;
using Blogger.IntegrationTests.Fixtures;
using FluentAssertions;

namespace Blogger.IntegrationTests.Articles;

public class CreateArticleCommandHandlerTests : IClassFixture<BloggerDbContextFixture>
{
    private readonly BloggerDbContextFixture _fixture;

    public CreateArticleCommandHandlerTests(BloggerDbContextFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task Handle_ShouldCreateArticle_WhenArticleDoesNotExist()
    {
        // Arrange
        var articleRepository = new ArticleRepository(_fixture.BuildDbContext(Guid.NewGuid().ToString()));
        var _sut = new CreateArticleCommandHandler(articleRepository);
        var command = new CreateArticleCommand("Test Title", "Test Body", "Test Summary", [Tag.Create("tag1"), Tag.Create("tag2")]);
        var articleId = ArticleId.CreateUniqueId("Test Title");

        // Act
        var response = await _sut.Handle(command, CancellationToken.None);

        // Assert
        response.Should().NotBeNull();
        response.ArticleId.Should().NotBeNull();
        response.ArticleId.Should().Be(articleId);

        var article = articleRepository.GetDraftByIdAsync(articleId, CancellationToken.None);
        article.Should().NotBeNull();
    }

    [Fact]
    public async Task Handle_ShouldThrowException_WhenArticleAlreadyExists()
    {
        // Arrange
        var articleRepository = new ArticleRepository(_fixture.BuildDbContext(Guid.NewGuid().ToString()));
        var _sut = new CreateArticleCommandHandler(articleRepository);
        var command = new CreateArticleCommand("Test Title", "Test Body", "Test Summary", [Tag.Create("tag1"), Tag.Create("tag2")]);
        var response = await _sut.Handle(command, CancellationToken.None);

        // Act
        Func<Task> act = async () => await _sut.Handle(command, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<ArticleAlreadyExistsException>();
    }

}
