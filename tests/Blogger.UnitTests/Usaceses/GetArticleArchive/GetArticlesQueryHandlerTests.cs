using Blogger.Application;
using Blogger.Application.Usecases.GetArticleArchive;
using Blogger.Domain.ArticleAggregate;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace Blogger.UnitTests.Usaceses.GetArticleArchive;

public class GetArticlesQueryHandlerTests
{
    public GetArticlesQueryHandlerTests()
    {
        var serviceCollection = new ServiceCollection();
        var configuration = new ConfigurationBuilder().Build();
        serviceCollection.ConfigureApplicationLayer(configuration);
        serviceCollection.BuildServiceProvider();
    }
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
        var handler = new GetArticlesQueryHandler(mockRepository.Object);


        //Act
        var result = await handler.Handle(new GetArticleArchiveQuery(), CancellationToken.None);

        //Assert
        result.Should().NotBeEmpty();
        result.Count.Should().Be(1);
        result.FirstOrDefault().Should().NotBeNull();
        result.FirstOrDefault()!.ArticleOnArchives.Count.Should().NotBe(0);
    }
}
