using Blogger.Application.Articles.GetPopularArticles;
using Blogger.Domain.ArticleAggregate;
using Blogger.Infrastructure.Persistence.Repositories;
using Blogger.IntegrationTests.Fixtures;

using FluentAssertions;

namespace Blogger.IntegrationTests.Articles;
public class GetPopularArticlesHandlerTests : IClassFixture<BloggerDbContextFixture>
{
    private readonly BloggerDbContextFixture _fixture;

    public GetPopularArticlesHandlerTests(BloggerDbContextFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task Handle_ShouldReturnPopularArticles_WhenArticlesExist()
    {
        // Arrange
        var articleRepository = new ArticleRepository(_fixture.BuildDbContext(Guid.NewGuid().ToString()));
        var _sut = new GetPopularArticlesHandler(articleRepository);

        var article_1 = Article.CreateArticle("Title 1", "Test Body", "Test Summary", [Tag.Create("tag1"), Tag.Create("tag2")]);
        var article_2 = Article.CreateArticle("Title 2", "Test Body", "Test Summary", [Tag.Create("tag1"), Tag.Create("tag2")]);
        var article_3 = Article.CreateArticle("Title 3", "Test Body", "Test Summary", [Tag.Create("tag1"), Tag.Create("tag2")]);

        var like_1 = Like.Create("127.0.0.1", DateTime.UtcNow);
        var like_2 = Like.Create("127.0.0.2", DateTime.UtcNow);
        var like_3 = Like.Create("127.0.0.3", DateTime.UtcNow);
        var like_4 = Like.Create("127.0.0.4", DateTime.UtcNow);
        var like_5 = Like.Create("127.0.0.1", DateTime.UtcNow);
        var like_6 = Like.Create("127.0.0.2", DateTime.UtcNow);
        var like_7 = Like.Create("127.0.0.3", DateTime.UtcNow);
        var like_8 = Like.Create("127.0.0.4", DateTime.UtcNow);
        var like_9 = Like.Create("127.0.0.1", DateTime.UtcNow);

        article_1.Like(like_1);
        article_1.Like(like_2);
        articleRepository.Add(article_1);

        article_2.Like(like_3);
        article_2.Like(like_4);
        article_2.Like(like_5);
        articleRepository.Add(article_2);

        article_3.Like(like_6);
        article_3.Like(like_7);
        article_3.Like(like_8);
        article_3.Like(like_9);
        articleRepository.Add(article_3);
        await articleRepository.SaveChangesAsync(CancellationToken.None);

        var request = new GetPopularArticlesQuery(2);

        // Act
        var response = await _sut.Handle(request, CancellationToken.None);

        // Assert
        response.Should().NotBeNull();
        response.Should().HaveCount(2);

        var firstArticleResponse = response.First();
        firstArticleResponse.ArticleId.Should().Be(article_3.Id);

        var secondArticleResponse = response.Last();
        secondArticleResponse.ArticleId.Should().Be(article_2.Id);
    }


    [Fact]
    public async Task Handle_ShouldReturnEmpty_WhenNoArticlesExist()
    {
        // Arrange
        var articleRepository = new ArticleRepository(_fixture.BuildDbContext(Guid.NewGuid().ToString()));
        var _sut = new GetPopularArticlesHandler(articleRepository);

        var request = new GetPopularArticlesQuery(2);

        // Act
        var response = await _sut.Handle(request, CancellationToken.None);

        // Assert
        response.Should().NotBeNull();
        response.Should().BeEmpty();
    }


}
