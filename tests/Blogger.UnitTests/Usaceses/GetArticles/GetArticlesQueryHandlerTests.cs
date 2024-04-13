using Blogger.Application;
using Blogger.Application.Usecases.GetArticles;
using Blogger.Domain.ArticleAggregate;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace Blogger.UnitTests.Usaceses.GetArticles;

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
    public async void GetArticleQuery_Should_Return_ImmutableArray_QueryResponse()
    {
        //Arrange
        var mockRepository = new Mock<IArticleRepository>();
        var client = Client.Create("fullname", "a@a.com");
        var mockArticles = new List<Blogger.Domain.ArticleAggregate.Article>
        {
            Blogger.Domain.ArticleAggregate.Article.CreateArticle("title1", "body1", "summary1"),
            Blogger.Domain.ArticleAggregate.Article.CreateArticle("title2", "body2", "summary2")
        }.AsReadOnly();
        mockRepository.Setup(s => s.GetLatestArticlesAsync(It.IsAny<int>(),
                                                           It.IsAny<int>(),
                                                           It.IsAny<CancellationToken>()))
                      .ReturnsAsync(mockArticles);
        var handler = new GetArticlesQueryHandler(mockRepository.Object);


        //Act
        var result = await handler.Handle(new GetArticlesQuery(),
                                          CancellationToken.None);

        //Assert
        result.Should().NotBeEmpty();
        result.Count.Should().Be(2);
        result.First().ArticleId.Should().BeSameAs(mockArticles.First().Id);
        result.Last().ArticleId.Should().BeSameAs(mockArticles.Last().Id);
    }
}
