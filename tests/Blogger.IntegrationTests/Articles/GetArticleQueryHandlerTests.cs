using Blogger.Application.Articles.GetArticle;
using Blogger.Application.Comments.MakeComment;
using Blogger.Domain.ArticleAggregate;
using Blogger.Infrastructure.Persistence.Repositories;
using Blogger.IntegrationTests.Fixtures;

using FluentAssertions;

namespace Blogger.IntegrationTests.Articles;
public class GetArticleQueryHandlerTests : IClassFixture<BloggerDbContextFixture>
{
    private readonly BloggerDbContextFixture _fixture;

    public GetArticleQueryHandlerTests(BloggerDbContextFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task Handle_ShouldReturnArticle_WhenArticleExists()
    {
        // Arrange
        var articleRepository = new ArticleRepository(_fixture.BuildDbContext(Guid.NewGuid().ToString()));
        var _sut = new GetArticleQueryHandler(articleRepository);

        var article = Article.CreateArticle("Title 1", "Test Body", "Test Summary", [Tag.Create("tag1"), Tag.Create("tag2")]);
        articleRepository.Add(article);
        await articleRepository.SaveChangesAsync(CancellationToken.None);
        var request = new GetArticleQuery(article.Id);
         
        // Act
        var response = await _sut.Handle(request, CancellationToken.None);

        // Assert
        response.Should().NotBeNull();
        response.ArticleId.Should().Be(article.Id);
        response.Title.Should().Be(article.Title);
        response.Body.Should().Be(article.Body);
        response.Summary.Should().Be(article.Summary);
        response.Tags.Should().BeEquivalentTo(article.Tags);
    }

    [Fact]
    public async Task Handle_ShouldThrowNotFoundArticleException_WhenArticleDoesNotExist()
    {
        // Arrange
        var articleRepository = new ArticleRepository(_fixture.BuildDbContext(Guid.NewGuid().ToString()));
        var _sut = new GetArticleQueryHandler(articleRepository);

        var articleId = ArticleId.Create("thisisnabi");
 
        var request = new GetArticleQuery(articleId);

        // Act
        Func<Task> act = async () => await _sut.Handle(request, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<NotFoundArticleException>();
    }

}
