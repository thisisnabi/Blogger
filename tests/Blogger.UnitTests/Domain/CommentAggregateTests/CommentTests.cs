using Blogger.Domain.ArticleAggregate;
using Blogger.Domain.CommentAggregate;

namespace Blogger.UnitTests.Domain.CommentAggregateTests;

public class CommentTests
{
    [Fact]
    public void Create_ShouldInitializeCorrectly()
    {
        // Arrange
        var articleId = ArticleId.CreateUniqueId("this-is-nabi");
        var client = Client.Create("nabi", "thisisnabi@outlook.com");
        var content = "This is a test comment.";
        var approveLink = ApproveLink.Create("approve-link", DateTime.UtcNow.AddDays(30));

        // Act
        var comment = Comment.Create(articleId, client, content, approveLink);

        // Assert
        comment.Should().NotBeNull();
        comment.ArticleId.Should().Be(articleId);
        comment.Client.Should().Be(client);
        comment.Content.Should().Be(content);
        comment.CreatedOnUtc.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));
        comment.IsApproved.Should().BeFalse();
        comment.ApproveLink.Should().Be(approveLink);
        comment.Replies.Should().BeEmpty();
    }

    [Fact]
    public void Approve_ShouldSetIsApprovedToTrue()
    {
        // Arrange
        var articleId = ArticleId.CreateUniqueId("this-is-nabi");
        var client = Client.Create("nabi", "thisisnabi@outlook.com");
        var content = "This is a test comment.";
        var approveLink = ApproveLink.Create("approve-link", DateTime.UtcNow.AddDays(30));

        var comment = Comment.Create(articleId, client, content, approveLink);
        // Act
        comment.Approve();

        // Assert
        comment.IsApproved.Should().BeTrue();
    }

    [Fact]
    public void ReplyComment_ShouldAddReplyToApprovedComment()
    {
        // Arrange
        var articleId = ArticleId.CreateUniqueId("this-is-nabi");
        var client = Client.Create("nabi", "thisisnabi@outlook.com");
        var content = "This is a test comment.";
        var approveLink = ApproveLink.Create("approve-link", DateTime.UtcNow.AddDays(30));
        var comment = Comment.Create(articleId, client, content, approveLink);

        // Act
        comment.Approve();
        var reply = comment.ReplyComment(client, content, approveLink);

        // Assert
        reply.Should().NotBeNull();
        reply.Content.Should().Be(content);
        reply.Client.Should().Be(client);
        reply.ApproveLink.Should().Be(approveLink);
        comment.Replies.Should().ContainSingle();
        comment.Replies.First().Should().Be(reply);
    }

    [Fact]
    public void ReplyComment_ShouldThrowExceptionIfCommentNotApproved()
    {
        // Arrange
        var articleId = ArticleId.CreateUniqueId("this-is-nabi");
        var client = Client.Create("nabi", "thisisnabi@outlook.com");
        var content = "This is a test comment.";
        var approveLink = ApproveLink.Create("approve-link", DateTime.UtcNow.AddDays(30));
        var comment = Comment.Create(articleId, client, content, approveLink);

        // Act
        Action act = () => comment.ReplyComment(client, "This is a reply.", approveLink);

        // Assert
        act.Should().Throw<UnapprovedCommentException>();
    }

    [Fact]
    public void ApproveReply_ShouldSetReplyAsApproved()
    {
        // Arrange
        var articleId = ArticleId.CreateUniqueId("this-is-nabi");
        var client = Client.Create("nabi", "thisisnabi@outlook.com");
        var content = "This is a test comment.";
        var approveLink = ApproveLink.Create("reply-approve-link", DateTime.UtcNow.AddDays(30));
        var comment = Comment.Create(articleId, client, content, approveLink);

        // Act
        comment.Approve();
        var reply = comment.ReplyComment(client, "This is a reply.", approveLink);
        var replyId = comment.ApproveReply("reply-approve-link");

        // Assert
        replyId.Should().Be(reply.Id);
        reply.IsApproved.Should().BeTrue();
    }

    [Fact]
    public void ApproveReply_ShouldThrowExceptionIfLinkIsInvalid()
    {
        // Arrange
        var articleId = ArticleId.CreateUniqueId("this-is-nabi");
        var client = Client.Create("nabi", "thisisnabi@outlook.com");
        var content = "This is a test comment.";
        var approveLink = ApproveLink.Create("approve-link", DateTime.UtcNow.AddDays(30));
        var comment = Comment.Create(articleId, client, content, approveLink);
        comment.Approve();
        comment.ReplyComment(client, "This is a reply.", approveLink);

        // Act
        Action act = () => comment.ApproveReply("invalid-link");

        // Assert
        act.Should().Throw<InvalidReplyApprovalLinkException>();
    }
}