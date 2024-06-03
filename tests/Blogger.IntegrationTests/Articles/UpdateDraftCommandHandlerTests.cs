using Blogger.Application.Articles.UpdateDraft;
using Blogger.Domain.ArticleAggregate;
using Blogger.Infrastructure.Persistence.Repositories;
using Blogger.IntegrationTests.Fixtures;

using FluentAssertions;

namespace Blogger.IntegrationTests.Articles;
public class UpdateDraftCommandHandlerTests : IClassFixture<BloggerDbContextFixture>
{
    private readonly BloggerDbContextFixture _fixture;

    public UpdateDraftCommandHandlerTests(BloggerDbContextFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task Handle_ShouldThrowDraftNotFoundException_WhenDraftDoesNotExist()
    {
        // Arrange
        var articleRepository = new ArticleRepository(_fixture.BuildDbContext(Guid.NewGuid().ToString()));
        var sut = new UpdateDraftCommandHandler(articleRepository);

        var draftId = ArticleId.Create("non-existent-draft-id");

        var command = new UpdateDraftCommand(draftId, "New Title", "New Body", "New Summary", [Tag.Create("tag")]);

        // Act
        Func<Task> act = async () => await sut.Handle(command, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<DraftNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowDraftTitleDuplicatedException_WhenNewDraftIdAlreadyExists()
    {
        // Arrange
        var articleRepository = new ArticleRepository(_fixture.BuildDbContext(Guid.NewGuid().ToString()));
        var sut = new UpdateDraftCommandHandler(articleRepository);

        var draftId = ArticleId.Create("existent-draft-id");
        var draft = Article.CreateDraft("ExistentDraft Id", "New Body", "New Summary");
        articleRepository.Add(draft);


        var draft_old = Article.CreateDraft("Old Draft", "Draft body", "Draft summary");
        draft_old.AddTags([Tag.Create("tag1")]);
        articleRepository.Add(draft_old);

        await articleRepository.SaveChangesAsync(CancellationToken.None);

        var command = new UpdateDraftCommand(draftId, "Old Draft", "New Body", "New Summary", [Tag.Create("tag")]);

        // Act
        Func<Task> act = async () => await sut.Handle(command, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<DraftTitleDuplicatedException>();
    }

    [Fact]
    public async Task Handle_ShouldUpdateDraft_WhenTitleIsSame()
    {
        // Arrange
        var articleRepository = new ArticleRepository(_fixture.BuildDbContext(Guid.NewGuid().ToString()));
        var sut = new UpdateDraftCommandHandler(articleRepository);

        var draftId = ArticleId.CreateUniqueId("Going UP");
        var draft = Article.CreateDraft("Going UP", "v1", "v1");
        draft.AddTags([Tag.Create("v1")]);

        articleRepository.Add(draft);
        await articleRepository.SaveChangesAsync(CancellationToken.None);

        var command = new UpdateDraftCommand(draftId, "Going UP", "v2", "v2", [Tag.Create("v2")]);

        // Act
        await sut.Handle(command, CancellationToken.None);

        // Assert
        var newDraft = await articleRepository.GetDraftByIdAsync(draftId, CancellationToken.None);
        newDraft.Should().NotBeNull();
        newDraft!.Title.Should().Be(command.Title);
        newDraft!.Summary.Should().Be(command.Summary);
        newDraft!.Body.Should().Be(command.Body);
        newDraft!.Tags.Should().BeEquivalentTo(command.Tags);
    }

    [Fact]
    public async Task Handle_ShouldDeleteOldDraftAndAddNewDraft_WhenTitleIsDifferent()
    {
        // Arrange
        var articleRepository = new ArticleRepository(_fixture.BuildDbContext(Guid.NewGuid().ToString()));
        var sut = new UpdateDraftCommandHandler(articleRepository);

        var draftId = ArticleId.CreateUniqueId("Going UP");
        var draftIdNew = ArticleId.CreateUniqueId("New Going UP");
        var draft = Article.CreateDraft("Going UP", "v1", "v1");
        draft.AddTags([Tag.Create("v1")]);

        articleRepository.Add(draft);
        await articleRepository.SaveChangesAsync(CancellationToken.None);

        var command = new UpdateDraftCommand(draftId, "New Going UP", "v2", "v2", [Tag.Create("v2")]);

        // Act
        await sut.Handle(command, CancellationToken.None);

        // Assert
        var oldDraft = await articleRepository.GetDraftByIdAsync(draftId, CancellationToken.None);
        oldDraft.Should().BeNull();  

        var newDraft = await articleRepository.GetDraftByIdAsync(draftIdNew, CancellationToken.None);
        newDraft.Should().NotBeNull();
        newDraft!.Title.Should().Be(command.Title);
        newDraft!.Summary.Should().Be(command.Summary);
        newDraft!.Body.Should().Be(command.Body);
        newDraft!.Tags.Should().BeEquivalentTo(command.Tags); 
    }
}
