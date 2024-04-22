using Blogger.Domain.CommentAggregate;

namespace Blogger.Application.Usecases.GetReplaies;

public class GetReplaiesHandler(ICommentRepository commentRepository)
    : IRequestHandler<GetReplaiesQuery, IReadOnlyList<GetReplaiesQueryResponse>>
{
    private readonly ICommentRepository _commentRepository = commentRepository;

    public async Task<IReadOnlyList<GetReplaiesQueryResponse>> Handle(GetReplaiesQuery request, CancellationToken cancellationToken)
    {
        var comments = await _commentRepository.GetApprovedReplaiesAsync(request.CommentId, cancellationToken);
        return comments.Select(x => (GetReplaiesQueryResponse)x)
                       .ToImmutableList();
    }
}
