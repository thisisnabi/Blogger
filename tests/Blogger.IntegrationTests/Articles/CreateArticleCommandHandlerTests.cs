using Blogger.Application.Articles.CreateArticle;
using Blogger.Domain.ArticleAggregate;
using Blogger.Infrastructure.Persistence.Repositories;
using Blogger.IntegrationTests.Fixtures;
using FluentAssertions;


namespace Blogger.IntegrationTests.Articles;
public class CreateArticleCommandHandlerTests : IClassFixture<BloggerDbContextFixture>
{
    private readonly CreateArticleCommandHandler _sut;

    public CreateArticleCommandHandlerTests(BloggerDbContextFixture fixture)
    {
        var articleRepository = new ArticleRepository(fixture.BuildDbContext());
        _sut = new CreateArticleCommandHandler(articleRepository);
    } 

    [Fact]
    public async Task Handle_ShouldCreateArticle_WhenArticleDoesNotExist()
    {
        // Arrange
        var command = new CreateArticleCommand("Test Title", "Test Body", "Test Summary", [Tag.Create("tag1"), Tag.Create("tag1")]);
    
        // Act
        var response = await _sut.Handle(command, CancellationToken.None);

        // Assert
        response.Should().NotBeNull();
        response.ArticleId.Should().NotBeNull();
        response.Should().Be("test-title");
    }

    //[Fact]
    //public async Task Handle_ShouldThrowException_WhenArticleAlreadyExists()
    //{
    //     Arrange
    //    var command = new CreateArticleCommand
    //    {
    //        Title = "Test Title",
    //        Body = "Test Body",
    //        Summary = "Test Summary",
    //        Tags = new[] { "tag1", "tag2" }
    //    };

    //    _articleRepositoryMock
    //        .Setup(repo => repo.HasIdAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
    //        .ReturnsAsync(true);

    //     Act
    //    Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

    //     Assert
    //    await act.Should().ThrowAsync<ArticleAlreadyExistsException>();

    //    _articleRepositoryMock.Verify(repo => repo.CreateAsync(It.IsAny<Article>(), It.IsAny<CancellationToken>()), Times.Never);
    //    _articleRepositoryMock.Verify(repo => repo.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
    //}
     
}
