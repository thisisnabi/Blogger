using Blogger.Domain.CommentAggregate;

namespace Blogger.Application.Comments.GetReplaies;
public record GetReplaiesQuery(CommentId CommentId)
    : IRequest<IReadOnlyList<GetReplaiesQueryResponse>>;