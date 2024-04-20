
using Blogger.Domain.CommentAggregate;

namespace Blogger.Application.Usecases.GetApprovedArticleComments;

public class GetApprovedArticleCommentsHandler(ICommentRepository commentRepository)
    : IRequestHandler<GetApprovedArticleCommentsQuery, IReadOnlyList<GetApprovedArticleCommentsQueryResponse>>
{
    private readonly ICommentRepository _commentRepository = commentRepository;

    public async Task<IReadOnlyList<GetApprovedArticleCommentsQueryResponse>> Handle(GetApprovedArticleCommentsQuery request, CancellationToken cancellationToken)
    {
        var comments = await _commentRepository.GetApprovedArticleCommentsAsync(request.ArticleId, cancellationToken);
        return comments.Adapt<IReadOnlyList<GetApprovedArticleCommentsQueryResponse>>();
    }
}
