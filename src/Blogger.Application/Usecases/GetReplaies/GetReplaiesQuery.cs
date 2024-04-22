using Blogger.Domain.CommentAggregate;

namespace Blogger.Application.Usecases.GetReplaies;
public record GetReplaiesQuery(CommentId CommentId) 
    : IRequest<IReadOnlyList<GetReplaiesQueryResponse>>;