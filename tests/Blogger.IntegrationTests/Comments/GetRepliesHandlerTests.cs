using Blogger.Application;
using Blogger.Application.Comments.GetReplies;
using Blogger.Domain.ArticleAggregate;
using Blogger.Domain.CommentAggregate;
using Blogger.Infrastructure.Persistence.Repositories;
using Blogger.Infrastructure.Services;
using Blogger.IntegrationTests.Fixtures;

using FluentAssertions;

namespace Blogger.IntegrationTests.Comments;

public class GetRepliesHandlerTests : IClassFixture<BloggerDbContextFixture>
{
    private readonly BloggerDbContextFixture _fixture;

    public GetRepliesHandlerTests(BloggerDbContextFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task Handle_NoRepliesFound_ShouldReturnEmptyList()
    {
        // Arrange
        var query = new GetRepliesQuery(CommentId.CreateUniqueId());
        var dbContext = _fixture.BuildDbContext(Guid.NewGuid().ToString());
        var commentRepository = new CommentRepository(dbContext);
        var sut = new GetRepliesHandler(commentRepository);

        // Act
        var result = await sut.Handle(query, CancellationToken.None);

        // Assert
        result.Should().BeEmpty();
    }


    [Fact]
    public async Task Handle_RepliesFound_ShouldReturnReplies()
    {
        // Arrange
        var articleId_1 = ArticleId.Create("this-is-nabi");

        var link = new LinkGenerator().Generate();
        var approveLinkComment = Domain.CommentAggregate.ApproveLink.Create(link, DateTime.UtcNow.AddHours(ApplicationSettings.ApproveLink.ExpairationOnHours));

        var client1 = Client.Create("Nabi Karampour 1", "thisisnabi@outlook.com");
        var client2 = Client.Create("Nabi Karampour 2", "thisisnabi@outlook.com");
        
        var comment1 = Comment.Create(articleId_1, client1, "Hi Bye 1", approveLinkComment);
        comment1.Approve();
        var replayContent = "Hi Bye -- Replay 1";
        var replay1 = comment1.ReplyComment(client1, replayContent, approveLinkComment);

        replay1.Approve();

        var comment2 = Comment.Create(articleId_1, client1, "Hi Bye 1", approveLinkComment);
        comment2.Approve();
        comment2.ReplyComment(client2, "Hi Bye -- Replay 2", approveLinkComment);

        var dbContext = _fixture.BuildDbContext(Guid.NewGuid().ToString());
        var commentRepository = new CommentRepository(dbContext);

        await commentRepository.CreateAsync(comment1, CancellationToken.None);
        await commentRepository.CreateAsync(comment2, CancellationToken.None);

        await commentRepository.SaveChangesAsync(CancellationToken.None);
        
        var query = new GetRepliesQuery(comment1.Id);

        var sut = new GetRepliesHandler(commentRepository);

        // act
        var result = await sut.Handle(query, CancellationToken.None);

        // assert
        result.Should().HaveCount(1);
        result.First().FullName.Should().Be(client1.FullName);
        result.First().Content.Should().Be(replayContent);
    }
}
