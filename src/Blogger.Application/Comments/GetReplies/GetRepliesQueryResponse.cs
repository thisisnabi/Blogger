using Blogger.Domain.CommentAggregate;

namespace Blogger.Application.Comments.GetReplies;

public record GetRepliesQueryResponse(string FullName, DateTime CreatedOnUtc, string Content)
{

    public static explicit operator GetRepliesQueryResponse(Reply Reply)
        => new GetRepliesQueryResponse(Reply.Client.FullName, Reply.CreatedOnUtc, Reply.Content);
}