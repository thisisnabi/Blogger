using Blogger.Domain.CommentAggregate;

namespace Blogger.Application.Usecases.GetArticleComments;

public class GetArticleCommentsHandler(ICommentRepository commentRepository)
    : IRequestHandler<GetArticleCommentsQuery, IReadOnlyList<GetArticleCommentsQueryResponse>>
{
    private readonly ICommentRepository _commentRepository = commentRepository;

    public async Task<IReadOnlyList<GetArticleCommentsQueryResponse>> Handle(GetArticleCommentsQuery request, CancellationToken cancellationToken)
    {
        var comments = await _commentRepository.GetApprovedArticleCommentsAsync(request.ArticleId, cancellationToken);
        return comments.Select(x => (GetArticleCommentsQueryResponse)x)
                       .ToImmutableList();
    }
}
