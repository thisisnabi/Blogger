using System.Collections.Immutable;
using Blogger.Application.Articles.GetTags;
using Blogger.Domain.ArticleAggregate;
using Blogger.Infrastructure.Persistence.Repositories;
using Blogger.IntegrationTests.Fixtures;

using FluentAssertions;

namespace Blogger.IntegrationTests.Articles;
public class GetTagsQueryHandlerTests : IClassFixture<BloggerDbContextFixture>
{
    private readonly BloggerDbContextFixture _fixture;

    public GetTagsQueryHandlerTests(BloggerDbContextFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task Handle_ShouldReturnTags_WhenTagsExist()
    {
        // Arrange
        var articleRepository = new ArticleRepository(_fixture.BuildDbContext(Guid.NewGuid().ToString()));
        var sut = new GetTagsQueryHandler(articleRepository);

        var article_1 = Article.CreateArticle("Title 1", "Test Body", "Test Summary", [Tag.Create("tag1"), Tag.Create("tag3")]);
        var article_2 = Article.CreateArticle("Title 2", "Test Body", "Test Summary", [Tag.Create("tag1"), Tag.Create("tag4")]);

        articleRepository.Add(article_1);
        articleRepository.Add(article_2);

        await articleRepository.SaveChangesAsync(CancellationToken.None);

        var request = new GetTagsQuery();

        // Act
        var response = (await sut.Handle(request, CancellationToken.None)).ToImmutableList();

        // Assert
        response.Should().NotBeNull();
        response.Should().HaveCount(3);

        response[0].Tag.Value.Should().Be("tag1");
        response[0].Count.Should().Be(2);

        response[1].Tag.Value.Should().Be("tag3");
        response[1].Count.Should().Be(1);

        response[2].Tag.Value.Should().Be("tag4");
        response[2].Count.Should().Be(1);
    }

    [Fact]
    public async Task Handle_ShouldReturnEmpty_WhenNoTagsExist()
    {
        // Arrange
        var articleRepository = new ArticleRepository(_fixture.BuildDbContext(Guid.NewGuid().ToString()));
        var sut = new GetTagsQueryHandler(articleRepository);

        var request = new GetTagsQuery();

        // Act
        var response = await sut.Handle(request, CancellationToken.None);

        // Assert
        response.Should().NotBeNull();
        response.Should().BeEmpty();
    }
}
