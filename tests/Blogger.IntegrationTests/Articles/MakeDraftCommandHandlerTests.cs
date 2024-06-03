using Blogger.Application.Articles.GetTags;
using Blogger.Application.Articles.MakeDraft;
using Blogger.Domain.ArticleAggregate;
using Blogger.Infrastructure.Persistence.Repositories;
using Blogger.IntegrationTests.Fixtures;

using FluentAssertions;

namespace Blogger.IntegrationTests.Articles;
public class MakeDraftCommandHandlerTests : IClassFixture<BloggerDbContextFixture>
{
    private readonly BloggerDbContextFixture _fixture;

    public MakeDraftCommandHandlerTests(BloggerDbContextFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task Handle_ShouldCreateDraft_WhenDraftDoesNotExist()
    {
        // Arrange
        var request = new MakeDraftCommand("Existing Draft", "Draft body", "Draft summary", []);
        var articleRepository = new ArticleRepository(_fixture.BuildDbContext(Guid.NewGuid().ToString()));
        var sut = new MakeDraftCommandHandler(articleRepository);
         
        // Act
        var response = await sut.Handle(request, CancellationToken.None);

        // Assert
        response.Should().NotBeNull();
        response.DraftId.Should().Be(ArticleId.CreateUniqueId(request.Title)); 
    }

    [Fact]
    public async Task Handle_ShouldThrowDraftAlreadyExistsException_WhenDraftAlreadyExists()
    {
        // Arrange
        var request = new MakeDraftCommand("Existing Draft", "Draft body", "Draft summary", []);
        var articleRepository = new ArticleRepository(_fixture.BuildDbContext(Guid.NewGuid().ToString()));
        var sut = new MakeDraftCommandHandler(articleRepository);

        var oldDraft = Article.CreateDraft("Existing Draft", "Draft body", "Draft summary");

        articleRepository.Add(oldDraft);
        await articleRepository.SaveChangesAsync(CancellationToken.None);

        // Act
        var draft = async () => await sut.Handle(request, CancellationToken.None);

        // Assert
        await draft.Should().ThrowAsync<DraftAlreadyExistsException>();
    }
}
