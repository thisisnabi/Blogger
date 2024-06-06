using Blogger.Application.Articles.GetArticles;
using Blogger.Domain.ArticleAggregate;
using System.Reflection.Metadata;

using Blogger.IntegrationTests.Fixtures;
using Blogger.Application.Articles.GetArticle;
using Blogger.Infrastructure.Persistence.Repositories;
using FluentAssertions;

namespace Blogger.IntegrationTests.Articles;
public class GetArticlesQueryHandlerTests : IClassFixture<BloggerDbContextFixture>
{
    private readonly BloggerDbContextFixture _fixture;

    public GetArticlesQueryHandlerTests(BloggerDbContextFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task Handle_ShouldReturnArticles_WhenArticlesExist()
    {
        // Arrange
        var articleRepository = new ArticleRepository(_fixture.BuildDbContext(Guid.NewGuid().ToString()));
        var _sut = new GetArticlesQueryHandler(articleRepository);


        var article_1 = Article.CreateArticle("Title 1", "Test Body", "Test Summary", [Tag.Create("tag1"), Tag.Create("tag2")]);
        var article_2 = Article.CreateArticle("Title 2", "Test Body", "Test Summary", [Tag.Create("tag1"), Tag.Create("tag2")]);

        articleRepository.Add(article_1);
        articleRepository.Add(article_2);
        await articleRepository.SaveChangesAsync(CancellationToken.None);

        var request = new GetArticlesQuery { PageNumber = 1, PageSize = 10 };

        // Act
        var response = await _sut.Handle(request, CancellationToken.None);

        // Assert
        response.Should().NotBeNull();
        response.Should().HaveCount(2);

        var firstArticleResponse = response.First();
        firstArticleResponse.ArticleId.Should().Be(article_2.Id);
        firstArticleResponse.Title.Should().Be(article_2.Title);
        firstArticleResponse.Summary.Should().Be(article_2.Summary);
        firstArticleResponse.PublishedOnUtc.Should().Be(article_2.PublishedOnUtc);
        firstArticleResponse.ReadOnMinutes.Should().Be(article_2.GetReadOnInMinutes);
        firstArticleResponse.Tags.Should().BeEquivalentTo(article_2.Tags);

        var secondArticleResponse = response.Last();
        secondArticleResponse.ArticleId.Should().Be(article_1.Id);
        secondArticleResponse.Title.Should().Be(article_1.Title);
        secondArticleResponse.Summary.Should().Be(article_1.Summary);
        secondArticleResponse.PublishedOnUtc.Should().Be(article_1.PublishedOnUtc);
        secondArticleResponse.ReadOnMinutes.Should().Be(article_1.GetReadOnInMinutes);
        secondArticleResponse.Tags.Should().BeEquivalentTo(article_1.Tags);
    }

    [Fact]
    public async Task Handle_ShouldReturnEmpty_WhenNoArticlesExist()
    {
        // Arrange
        var articleRepository = new ArticleRepository(_fixture.BuildDbContext(Guid.NewGuid().ToString()));
        var _sut = new GetArticlesQueryHandler(articleRepository);

        var request = new GetArticlesQuery { PageNumber = 1, PageSize = 10 };

        // Act
        var response = await _sut.Handle(request, CancellationToken.None);

        // Assert
        response.Should().NotBeNull();
        response.Should().BeEmpty();
    }

}
