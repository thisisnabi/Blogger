using Blogger.Domain.CommentAggregate;

namespace Blogger.Application.Comments.GetComments;

public record GetCommentsQueryResponse(string FullName, DateTime CreatedOnUtc, string Content)
{

    public static explicit operator GetCommentsQueryResponse(Comment comment)
        => new GetCommentsQueryResponse(comment.Client.FullName, comment.CreatedOnUtc, comment.Content);
}