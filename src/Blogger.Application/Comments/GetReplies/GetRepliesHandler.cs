using Blogger.Domain.CommentAggregate;

namespace Blogger.Application.Comments.GetReplies;

public class GetRepliesHandler(ICommentRepository commentRepository)
    : IRequestHandler<GetRepliesQuery, IReadOnlyCollection<GetRepliesQueryResponse>>
{
    private readonly ICommentRepository _commentRepository = commentRepository;

    public async Task<IReadOnlyCollection<GetRepliesQueryResponse>> Handle(GetRepliesQuery request, CancellationToken cancellationToken)
    {
        var comments = await _commentRepository.GetApprovedRepliesAsync(request.CommentId, cancellationToken);
        return [.. comments.Select(x => (GetRepliesQueryResponse)x)];
    }
}
