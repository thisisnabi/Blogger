using Blogger.Domain.CommentAggregate;

namespace Blogger.Application.Comments.GetComments;

public record GetCommentsQueryResponse(CommentId CommentId,string FullName, DateTime CreatedOnUtc, string Content)
{

    public static explicit operator GetCommentsQueryResponse(Comment comment)
        => new GetCommentsQueryResponse(comment.Id,comment.Client.FullName, comment.CreatedOnUtc, comment.Content);
}