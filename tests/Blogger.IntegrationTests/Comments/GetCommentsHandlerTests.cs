using System.Reflection.Metadata;

using Blogger.Application;
using Blogger.Application.Comments.GetComments;
using Blogger.Domain.ArticleAggregate;
using Blogger.Domain.CommentAggregate;
using Blogger.Infrastructure.Persistence.Repositories;
using Blogger.Infrastructure.Services;
using Blogger.IntegrationTests.Fixtures;

using FluentAssertions;

using NSubstitute;

namespace Blogger.IntegrationTests.Comments;
public class GetCommentsHandlerTests : IClassFixture<BloggerDbContextFixture>
{
    private readonly BloggerDbContextFixture _fixture;

    public GetCommentsHandlerTests(BloggerDbContextFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task Handle_NoCommentsFound_ShouldReturnEmptyList()
    {
        // Arrange
        var dbContext = _fixture.BuildDbContext(Guid.NewGuid().ToString());
        var commentRepository = new CommentRepository(dbContext);

        var articleId = ArticleId.Create("this-is-nabi");
        var query = new GetCommentsQuery(articleId);

        var sut = new GetCommentsHandler(commentRepository);

        // Act
        var result = await sut.Handle(query, CancellationToken.None);

        // Assert
        result.Should().BeEmpty();
    }

    [Fact]
    public async Task Handle_CommentsFound_ShouldReturnComments()
    {
        // Arrange
        var articleId_1 = ArticleId.Create("this-is-nabi");
        var articleId_2 = ArticleId.Create("this-is-nabi_2");

        var link = new LinkGenerator().Generate();
        var approveLinkComment = ApproveLink.Create(link, DateTime.UtcNow.AddHours(ApplicationSettings.ApproveLink.ExpirationOnHours));

        var client1 = Client.Create("Nabi Karampour 1", "thisisnabi@outlook.com");
        var client2 = Client.Create("Nabi Karampour 2", "thisisnabi@outlook.com");
        var comment1 = Comment.Create(articleId_1, client1, "Hi Bye 1", approveLinkComment);
        comment1.Approve();
        
        var comment2 = Comment.Create(articleId_2, client2, "Hi Bye 2", approveLinkComment);
        comment2.Approve();

        var query = new GetCommentsQuery(articleId_1);

        var dbContext = _fixture.BuildDbContext(Guid.NewGuid().ToString());
        var commentRepository = new CommentRepository(dbContext);

        await commentRepository.CreateAsync(comment1, CancellationToken.None);
        await commentRepository.CreateAsync(comment2, CancellationToken.None);

        await commentRepository.SaveChangesAsync(CancellationToken.None);

        var sut = new GetCommentsHandler(commentRepository);

        // Act
        var result = await sut.Handle(query, CancellationToken.None);

        // Assert
        result.Should().HaveCount(1);
        result.First().FullName.Should().Be(client1.FullName);
        result.First().Content.Should().Be(comment1.Content);
    }
}
