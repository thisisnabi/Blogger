using Blogger.Application.Usecases.GetApprovedArticleComments;
using Blogger.Domain.ArticleAggregate;
using Blogger.Domain.CommentAggregate;
using Moq;

namespace Blogger.UnitTests.Usaceses.GetArticleComments;

public class GetApprovedArticleCommentsHandlerTests : IClassFixture<TestFixture>
{

    [Fact]
    public async void ApproveArticleCommentQuery_Should_Return_ImmutableArray_QueryResponse()
    {
        //Arrange
        var mockRepository = new Mock<IArticleRepository>();
        var client = Client.Create("fullname", "a@a.com");
        var mockComments = new List<Comment>
        {
            Comment.Create(client ,"content1"),
            Comment.Create(client ,"content2")
        }.AsReadOnly();
        mockRepository.Setup(s => s.GetApprovedArticleCommentsAsync(It.IsAny<ArticleId>(), It.IsAny<CancellationToken>()))
                      .ReturnsAsync(mockComments);
        var handler = new GetApprovedArticleCommentsHandler(mockRepository.Object);


        //Act
        var result = await handler.Handle(new GetApprovedArticleCommentsQuery(ArticleId.CreateUniqueId("title")),
                                          CancellationToken.None);

        //Assert
        result.Should().NotBeEmpty();
        result.Count.Should().Be(mockComments.Count);
        result.First().Content.Should().BeSameAs(mockComments.First().Content);
        result.Last().Content.Should().BeSameAs(mockComments.Last().Content);
    }
}
