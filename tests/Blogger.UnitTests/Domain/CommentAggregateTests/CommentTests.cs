using Blogger.Domain.ArticleAggregate;
using Blogger.Domain.CommentAggregate;

namespace Blogger.UnitTests.Domain.CommentAggregateTests;

public class CommentTests
{
    #region [Tests]

    [Fact]
    public void Create_ShouldInitializeCorrectly()
    {
        // Arrange
        var articleId = ArticleId.CreateUniqueId("this-is-nabi");
        var content = "This is a test comment.";

        // Act
        var comment = SetupCommentData("approve-link", content);

        // Assert
        comment.Should().NotBeNull();
        comment.commentResponse.ArticleId.Should().Be(articleId);
        comment.commentResponse.Client.Should().Be(comment.client);
        comment.commentResponse.Content.Should().Be(content);
        comment.commentResponse.CreatedOnUtc.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));
        comment.commentResponse.IsApproved.Should().BeFalse();
        comment.commentResponse.ApproveLink.Should().Be(comment.approveLink);
        comment.commentResponse.Replies.Should().BeEmpty();
    }

    [Fact]
    public void Approve_ShouldSetIsApprovedToTrue()
    {
        // Arrange       
        var content = "This is a test comment.";
        var comment = SetupCommentData("approve-link", content);

        // Act
        comment.commentResponse.Approve();

        // Assert
        comment.commentResponse.IsApproved.Should().BeTrue();
    }

    [Fact]
    public void ReplyComment_ShouldAddReplyToApprovedComment()
    {
        // Arrange
        var content = "This is a test comment.";
        var comment = SetupCommentData("reply-approve-link", content);

        // Act
        comment.commentResponse.Approve();
        var reply = comment.commentResponse.ReplyComment(comment.client, content, comment.approveLink);

        // Assert
        reply.Should().NotBeNull();
        reply.Content.Should().Be(content);
        reply.Client.Should().Be(comment.client);
        reply.ApproveLink.Should().Be(comment.approveLink);
        comment.commentResponse.Replies.Should().ContainSingle();
        comment.commentResponse.Replies.First().Should().Be(reply);
    }

    [Fact]
    public void ReplyComment_ShouldThrowExceptionIfCommentNotApproved()
    {
        // Arrange
        string content = "This is a reply.";
        var comment = SetupCommentData("approve-link", content);

        // Act
        Action act = () => comment.commentResponse.ReplyComment(comment.client, content, comment.approveLink);

        // Assert
        act.Should().Throw<UnapprovedCommentException>();
    }

    [Fact]
    public void ApproveReply_ShouldSetReplyAsApproved()
    {
        // Arrange
        string content = "This is a reply.";
        var comment = SetupCommentData("reply-approve-link", content);

        // Act
        comment.commentResponse.Approve();
        var reply = comment.commentResponse.ReplyComment(comment.client, content, comment.approveLink);
        var replyId = comment.commentResponse.ApproveReply("reply-approve-link");

        // Assert
        replyId.Should().Be(reply.Id);
        reply.IsApproved.Should().BeTrue();
    }

    [Fact]
    public void ApproveReply_ShouldThrowExceptionIfLinkIsInvalid()
    {
        // Arrange
        string content = "This is a reply.";
        var comment = SetupCommentData("approve-link", content);
        comment.commentResponse.Approve();
        comment.commentResponse.ReplyComment(comment.client, content, comment.approveLink);

        // Act
        Action act = () => comment.commentResponse.ApproveReply("invalid-link");

        // Assert
        act.Should().Throw<InvalidReplyApprovalLinkException>();
    }

    #endregion [Tests]

    #region [Private Method]

    /// <summary>
    /// Data setup method to use across the comment test class  
    /// </summary>
    /// <param name="link">Approve link</param>
    /// <param name="content">Content to use</param>
    /// <returns>Return Comment, Client & Approve link</returns>
    private static (Comment commentResponse, Client client, ApproveLink approveLink) SetupCommentData(string link, string content)
    {
        var articleId = ArticleId.CreateUniqueId("this-is-nabi");
        var client = Client.Create("nabi", "thisisnabi@outlook.com");
        var approveLink = ApproveLink.Create(link, DateTime.UtcNow.AddDays(30));
        var comment = Comment.Create(articleId, client, content, approveLink);
        return (comment, client, approveLink);
    }

    #endregion
}