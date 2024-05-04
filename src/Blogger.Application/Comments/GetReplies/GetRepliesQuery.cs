using Blogger.Domain.CommentAggregate;

namespace Blogger.Application.Comments.GetReplies;
public record GetRepliesQuery(CommentId CommentId)
    : IRequest<IReadOnlyList<GetRepliesQueryResponse>>;