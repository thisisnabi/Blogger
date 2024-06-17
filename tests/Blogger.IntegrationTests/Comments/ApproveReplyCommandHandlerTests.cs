using Blogger.Application;
using Blogger.Application.Comments.ApproveComment;
using Blogger.Application.Comments.ApproveReply;
using Blogger.Domain.ArticleAggregate;
using Blogger.Domain.CommentAggregate;
using Blogger.Infrastructure.Persistence.Repositories;
using Blogger.Infrastructure.Services;
using Blogger.IntegrationTests.Fixtures;

using FluentAssertions;

namespace Blogger.IntegrationTests.Comments;
public class ApproveReplyCommandHandlerTests : IClassFixture<BloggerDbContextFixture>
{
    private readonly BloggerDbContextFixture _fixture;

    public ApproveReplyCommandHandlerTests(BloggerDbContextFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task Handle_CommentNotFound_ShouldThrowCommentNotFoundException()
    {
        // Arrange
        var dbContext = _fixture.BuildDbContext(Guid.NewGuid().ToString());

        var command = new ApproveReplyCommand(CommentId.CreateUniqueId(), "invalid-link");
        var commentRepository = new CommentRepository(dbContext);
        var sut = new ApproveReplyCommandHandler(commentRepository);

        // Act
        Func<Task> act = async () => await sut.Handle(command, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<CommentNotFoundException>();
    }

    [Fact]
    public async Task Handle_CommentFound_ShouldApproveReplyAndSaveChanges()
    {
        // Arrange
        var link = new LinkGenerator().Generate();
        var approveLinkComment = ApproveLink.Create(link, DateTime.UtcNow.AddHours(ApplicationSettings.ApproveLink.ExpairationOnHours));
        var approveLink = ApproveLink.Create(link, DateTime.UtcNow.AddHours(ApplicationSettings.ApproveLink.ExpairationOnHours));

        var dbContext = _fixture.BuildDbContext(Guid.NewGuid().ToString());
        var commentRepository = new CommentRepository(dbContext);

        var articleId = ArticleId.Create("this-is-nabi");
        var client = Client.Create("Nabi Karampour", "thisisnabi@outlook.com");
        var comment = Comment.Create(articleId, client, "Hi Bye", approveLinkComment);
        comment.Approve();
        var replay =comment.ReplyComment(client, "Hi Bye", approveLink);

        await commentRepository.CreateAsync(comment, CancellationToken.None);
        await commentRepository.SaveChangesAsync(CancellationToken.None);

        var command = new ApproveReplyCommand(comment.Id, approveLink.ApproveId);
        var sut = new ApproveReplyCommandHandler(commentRepository);

        // Act
        var response = await sut.Handle(command, CancellationToken.None);

        // Assert
        response.ArticleId.Should().Be(articleId);
        response.CommentId.Should().Be(comment.Id);
        response.ReplyId.Should().Be(replay.Id);
        replay.IsApproved.Should().BeTrue();
    }
}
