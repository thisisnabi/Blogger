using Blogger.Application.ApplicationServices;
using Blogger.Application.Articles;
using Blogger.Application.Comments.MakeComment;
using Blogger.Domain.ArticleAggregate;
using Blogger.Domain.CommentAggregate;
using Blogger.Infrastructure.Persistence.Repositories;
using Blogger.Infrastructure.Services;
using Blogger.IntegrationTests.Fixtures;
using FluentAssertions;
using NSubstitute;

namespace Blogger.IntegrationTests.Comments;
public class MakeCommentCommandHandlerTests : IClassFixture<BloggerDbContextFixture>
{
    private readonly BloggerDbContextFixture _fixture;

    public MakeCommentCommandHandlerTests(BloggerDbContextFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task Handle_ShouldThrowNotFoundArticleException_ForInvalidArticleId()
    {
        // Arrange
        var command = new MakeCommentCommand(ArticleId.Create("this-is-nabi"), Client.Create("", "thisisnabi@gmail.com"), "Test Content");

        var dbContext = _fixture.BuildDbContext(Guid.NewGuid().ToString());
        var commentRepository = new CommentRepository(dbContext);
        var articleRepository = new ArticleRepository(dbContext);
        var articleService = new ArticleService(articleRepository);
        var linkGenerator = new LinkGenerator();

        var emailService = Substitute.For<IEmailService>();
        var sut = new MakeCommentCommandHandler(commentRepository, articleService, emailService, linkGenerator);

        // Act
        Func<Task> act = async () => await sut.Handle(command, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<NotFoundArticleException>();
    }


    [Fact]
    public async Task Handle_ShouldCreateComment_ForValidArticleId()
    {
        // Arrange
        var articleId = ArticleId.Create("this-is-nabi");
        var command = new MakeCommentCommand(articleId, Client.Create("Nabi Karampour", "thisisnabi@gmail.com"), "Test Content");

        var dbContext = _fixture.BuildDbContext(Guid.NewGuid().ToString());
        var articleRepository = new ArticleRepository(dbContext);
        articleRepository.Add(Article.CreateArticle("This Is Nabi", "Nabi", "Nabi", [Tag.Create("test")]));
        await articleRepository.SaveChangesAsync(CancellationToken.None);

        var commentRepository = new CommentRepository(dbContext);
        var articleService = new ArticleService(articleRepository);
        var linkGenerator = new LinkGenerator();

        var emailService = Substitute.For<IEmailService>();
        var sut = new MakeCommentCommandHandler(commentRepository, articleService, emailService, linkGenerator);

        // Act
        var result = await sut.Handle(command, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.CommentId.Should().NotBe(Guid.Empty);
        await emailService.Received(1).SendAsync(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<CancellationToken>());

        var comment = await commentRepository.GetCommentByIdAsync(result.CommentId, CancellationToken.None);
        comment.Should().NotBeNull();
    }

}
