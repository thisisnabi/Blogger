using Blogger.Domain.CommentAggregate;

namespace Blogger.Application.Comments.GetReplies;

public class GetRepliesHandler(ICommentRepository commentRepository)
    : IRequestHandler<GetRepliesQuery, IReadOnlyList<GetRepliesQueryResponse>>
{
    private readonly ICommentRepository _commentRepository = commentRepository;

    public async Task<IReadOnlyList<GetRepliesQueryResponse>> Handle(GetRepliesQuery request, CancellationToken cancellationToken)
    {
        var comments = await _commentRepository.GetApprovedRepliesAsync(request.CommentId, cancellationToken);
        return comments.Select(x => (GetRepliesQueryResponse)x)
                       .ToImmutableList();
    }
}
