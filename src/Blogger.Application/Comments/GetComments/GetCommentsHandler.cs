using Blogger.Domain.CommentAggregate;

namespace Blogger.Application.Comments.GetComments;

public class GetCommentsHandler(ICommentRepository commentRepository)
    : IRequestHandler<GetCommentsQuery, IReadOnlyList<GetCommentsQueryResponse>>
{
    private readonly ICommentRepository _commentRepository = commentRepository;

    public async Task<IReadOnlyList<GetCommentsQueryResponse>> Handle(GetCommentsQuery request, CancellationToken cancellationToken)
    {
        var comments = await _commentRepository.GetApprovedArticleCommentsAsync(request.ArticleId, cancellationToken);
        return comments.Select(x => (GetCommentsQueryResponse)x)
                       .ToImmutableList();
    }
}
