using System.Reflection.Metadata;

using Blogger.Application;
using Blogger.Application.ApplicationServices;
using Blogger.Application.Articles;
using Blogger.Application.Comments.ApproveComment;
using Blogger.Application.Comments.MakeComment;
using Blogger.Domain.ArticleAggregate;
using Blogger.Domain.CommentAggregate;
using Blogger.Infrastructure.Persistence.Repositories;
using Blogger.Infrastructure.Services;
using Blogger.Infrastructure.Services.Externals;
using Blogger.IntegrationTests.Fixtures;

using FluentAssertions;

namespace Blogger.IntegrationTests.Comments;
public class ApproveCommentCommandHandlerTests : IClassFixture<BloggerDbContextFixture>
{
    private readonly BloggerDbContextFixture _fixture;

    public ApproveCommentCommandHandlerTests(BloggerDbContextFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task Handle_CommentNotFound_ShouldThrowInvalidCommentApprovalLinkException()
    {
        // Arrange
        var dbContext = _fixture.BuildDbContext(Guid.NewGuid().ToString());
        var commentRepository = new CommentRepository(dbContext);
        var command = new ApproveCommentCommand("invalid-link");

        var sut = new ApproveCommentCommandHandler(commentRepository);

        // Act
        Func<Task> act = async () => await sut.Handle(command, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<InvalidCommentApprovalLinkException>();
    }


    [Fact]
    public async Task Handle_CommentFound_ShouldApproveCommentAndSaveChanges()
    {
        // Arrange
        var link = new LinkGenerator().Generate();
        var approveLink = ApproveLink.Create(link, DateTime.UtcNow.AddHours(ApplicationSettings.ApproveLink.ExpirationOnHours));

        var command = new ApproveCommentCommand(approveLink.ApproveId);
        var dbContext = _fixture.BuildDbContext(Guid.NewGuid().ToString());
        var commentRepository = new CommentRepository(dbContext);

        var articleId = ArticleId.Create("this-is-nabi");
        var comment =  Comment.Create(articleId, Client.Create("Nabi Karampour", "thisisnabi@outlook.com"),"Hi Bye", approveLink);
        await commentRepository.CreateAsync(comment, CancellationToken.None);
        await commentRepository.SaveChangesAsync(CancellationToken.None);

        var sut = new ApproveCommentCommandHandler(commentRepository);

        // Act
        var response = await sut.Handle(command, CancellationToken.None);

        // Assert
        response.ArticleId.Should().Be(articleId);
        response.CommentId.Should().Be(comment.Id);
        comment.IsApproved.Should().BeTrue();
    }
}
