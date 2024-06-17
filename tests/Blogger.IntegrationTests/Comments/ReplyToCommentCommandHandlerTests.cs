using Blogger.Application.Comments.ReplyToComment;
using Blogger.Domain.CommentAggregate;
using System.Reflection.Metadata;

using Blogger.IntegrationTests.Fixtures;

using FluentAssertions;

using NSubstitute;
using Blogger.Infrastructure.Persistence.Repositories;
using Blogger.Application.Articles;
using Blogger.Application.Comments.MakeComment;
using Blogger.Infrastructure.Services.Externals;
using Blogger.Infrastructure.Services;
using Blogger.Application.ApplicationServices;
using Blogger.Application;
using Blogger.Domain.ArticleAggregate;
using Microsoft.EntityFrameworkCore;

namespace Blogger.IntegrationTests.Comments;

public class ReplyToCommentCommandHandlerTests : IClassFixture<BloggerDbContextFixture>
{
    private readonly BloggerDbContextFixture _fixture;

    public ReplyToCommentCommandHandlerTests(BloggerDbContextFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task Handle_CommentNotFound_ShouldThrowNotFoundCommentException()
    {
        // Arrange
        var commentId = CommentId.CreateUniqueId();
        var command = new ReplyToCommentCommand (commentId, Client.Create("Nabi Karampour","thisisnabi@outlook.com"), "Test content");
        var dbContext = _fixture.BuildDbContext(Guid.NewGuid().ToString());
        var commentRepository = new CommentRepository(dbContext);
        
        var linkGenerator = new LinkGenerator();
        var emailService = Substitute.For<IEmailService>();
        var sut = new ReplyToCommentCommandHandler(commentRepository, emailService, linkGenerator);

        // Act
        Func<Task> act = async () => await sut.Handle(command, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<NotFoundCommentException>();
    }

    [Fact]
    public async Task Handle_CommentFound_ShouldReplyToCommentAndSendEmail()
    {
        // Arrange
        var link = new LinkGenerator().Generate();
        var approvelink = ApproveLink.Create(link, DateTime.UtcNow.AddHours(ApplicationSettings.ApproveLink.ExpairationOnHours));

        var articleId = ArticleId.Create("this-is-nabi");
        var client = Client.Create("Nabi Karampour", "thisisnabi@outlook.com");
        var comment = Comment.Create(articleId, client, "Hi Bye", approvelink);

        comment.Approve();

        var dbContext = _fixture.BuildDbContext(Guid.NewGuid().ToString());
        var commentRepository = new CommentRepository(dbContext);
        await commentRepository.CreateAsync(comment, CancellationToken.None);
        await commentRepository.SaveChangesAsync(CancellationToken.None);

        var linkGenerator = new LinkGenerator();
        var emailService = Substitute.For<IEmailService>();

        var sut = new ReplyToCommentCommandHandler(commentRepository, emailService, linkGenerator);
        var replayCommand = new ReplyToCommentCommand(comment.Id, client, "Hi Bye");
 
        // Act
        var response = await sut.Handle(replayCommand, CancellationToken.None);

        // Assert
        response.ReplyId.Should().NotBeNull();
        await emailService.Received(1).SendAsync(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<CancellationToken>());
    }
}
