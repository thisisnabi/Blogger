using Blogger.Application.Articles.MakeDraft;
using Blogger.Application.Articles.PublishDraft;
using Blogger.Application.Articles.UpdateDraft;
using Blogger.Domain.ArticleAggregate;
using Blogger.Infrastructure.Persistence.Repositories;
using Blogger.IntegrationTests.Fixtures;

using FluentAssertions;

namespace Blogger.IntegrationTests.Articles;
public class PublishDraftCommandHandlerTests : IClassFixture<BloggerDbContextFixture>
{
    private readonly BloggerDbContextFixture _fixture;

    public PublishDraftCommandHandlerTests(BloggerDbContextFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task Handle_ShouldPublishDraft_WhenDraftExists()
    {
        // Arrange
        var request = new MakeDraftCommand("Existing Draft", "Draft body", "Draft summary", []);
        var articleRepository = new ArticleRepository(_fixture.BuildDbContext(Guid.NewGuid().ToString()));
        var sut = new PublishDraftCommandHandler(articleRepository);

        var draftId = ArticleId.CreateUniqueId("Existing Draft");
        var draft = Article.CreateDraft("Existing Draft", "Draft body", "Draft summary");
        draft.AddTags([Tag.Create("tag1")]);

        articleRepository.Add(draft);
        await articleRepository.SaveChangesAsync(CancellationToken.None);

        // Act
        await sut.Handle(new PublishDraftCommand(draftId), CancellationToken.None);

        // Assert
        var article = await articleRepository.GetArticleByIdAsync(draftId, CancellationToken.None);
        article.Should().NotBeNull();
        article!.Id.Should().Be(draftId);
    }

    [Fact]
    public async Task Handle_ShouldThrowDraftNotFoundException_WhenDraftDoesNotExist()
    {
        // Arrange
        var request = new MakeDraftCommand("Not Existing Draft", "Draft body", "Draft summary", []);
        var articleRepository = new ArticleRepository(_fixture.BuildDbContext(Guid.NewGuid().ToString()));
        var sut = new PublishDraftCommandHandler(articleRepository);
        var draftId = ArticleId.CreateUniqueId("Nothing");

        // Act
        Func<Task> act = async () => await sut.Handle(new PublishDraftCommand(draftId), CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<DraftNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowDraftTagsMissingException_WhenDraftDoesNotHaveTags()
    {
        // Arrange
        var request = new MakeDraftCommand("Not Existing Draft", "Draft body", "Draft summary", []);
        var articleRepository = new ArticleRepository(_fixture.BuildDbContext(Guid.NewGuid().ToString()));
        var sut = new PublishDraftCommandHandler(articleRepository);
        var draftId = ArticleId.CreateUniqueId("Not Existing Draft");
        var draft = Article.CreateDraft("Not Existing Draft", "Draft body", "Draft summary");

        articleRepository.Add(draft);
        await articleRepository.SaveChangesAsync(CancellationToken.None);

        // Act
        Func<Task> act = async () => await sut.Handle(new PublishDraftCommand(draftId), CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<DraftTagsMissingException>();
    }
}
