using Blogger.Domain.CommentAggregate;

namespace Blogger.Application.Usecases.GetArticleComments;

public record GetArticleCommentsQueryResponse(string FullName, DateTime CreatedOnUtc, string Content)
{

    public static explicit operator GetArticleCommentsQueryResponse(Comment comment)
        => new GetArticleCommentsQueryResponse(comment.Client.FullName,comment.CreatedOnUtc, comment.Content);
}