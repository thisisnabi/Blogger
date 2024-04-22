using Blogger.Domain.ArticleAggregate;
using Blogger.Domain.CommentAggregate;

namespace Blogger.UnitTests.Article;

public class ArticleTests
{
    //[Fact]
    //public void AddCommentOnDraftArticle_Should_ThrowException()
    //{
    //    //Arrange
    //    var article = Blogger.Domain.ArticleAggregate.Article.CreateDraft("title", "body", "summary");
    //    var comment = Comment.Create(Client.Create("FullName", "a@a.com"), "content");

    //    //Act
    //    //Assert
    //    article.Invoking(x => x.AddComment(comment))
    //        .Should()
    //        .Throw<InvalidArticleActionException>()
    //        .WithMessage($"Invalid action on {ArticleStatus.Draft} status");

    //}
    //[Fact]
    //public void AddCommentOnDeleteArticle_Should_ThrowException()
    //{
    //    //Arrange
    //    var article = Blogger.Domain.ArticleAggregate.Article.CreateDraft("title", "body", "summary");
    //    article.Remove();
    //    var comment = Comment.Create(Client.Create("FullName", "a@a.com"), "content");

    //    //Act
    //    //Assert
    //    article.Invoking(x => x.AddComment(comment))
    //        .Should()
    //        .Throw<InvalidArticleActionException>()
    //        .WithMessage($"Invalid action on {ArticleStatus.Deleted} status");

    //}
    //[Fact]
    //public void AddCommentOnPublishedArticle_Should_Be_Success()
    //{
    //    //Arrange
    //    var article = Blogger.Domain.ArticleAggregate.Article.CreateArticle("title", "body", "summary");
    //    var comment = Comment.Create(Client.Create("FullName", "a@a.com"), "content");

    //    //Act
    //    article.AddComment(comment);

    //    //Assert
    //    article.Commnets.Should().HaveCount(1);

    //}
}
