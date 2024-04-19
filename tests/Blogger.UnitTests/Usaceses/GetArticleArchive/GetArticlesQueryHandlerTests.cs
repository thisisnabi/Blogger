using Blogger.Application.Usecases.GetArticleArchive;
using Blogger.Domain.ArticleAggregate;
using Moq;

namespace Blogger.UnitTests.Usaceses.GetArticleArchive;

public class GetArticlesQueryHandlerTests : IClassFixture<TestFixture>
{

    [Fact]
    public async void ArticleArchiveQuery_Should_Return_ImmutableArray_QueryResponse()
    {
        //Arrange
        var mockRepository = new Mock<IArticleRepository>();
        var mockArticles = new List<Blogger.Domain.ArticleAggregate.Article>
        {
            Blogger.Domain.ArticleAggregate.Article.CreateArticle("title", "body", "summary"),
            Blogger.Domain.ArticleAggregate.Article.CreateArticle("title", "body", "summary")
        }.AsReadOnly();
        mockRepository.Setup(s => s.GetArchiveArticlesAsync(It.IsAny<CancellationToken>()))
                      .ReturnsAsync(mockArticles);
        var handler = new GetArchiveQueryHandler(mockRepository.Object);


        //Act
        var result = await handler.Handle(new GetArchiveQuery(), CancellationToken.None);

        //Assert
        result.Should().NotBeEmpty();
        result.Count.Should().Be(1);
        result.FirstOrDefault().Should().NotBeNull();
        result.FirstOrDefault()!.ArticleOnArchives.Count.Should().NotBe(0);
    }
}
