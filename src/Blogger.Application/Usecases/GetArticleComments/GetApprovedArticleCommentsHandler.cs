
namespace Blogger.Application.Usecases.GetApprovedArticleComments;

public class GetApprovedArticleCommentsHandler(IArticleRepository articleRepository)
    : IRequestHandler<GetApprovedArticleCommentsQuery, IReadOnlyList<GetApprovedArticleCommentsResponse>>
{
    private readonly IArticleRepository _articleRepository = articleRepository;

    public async Task<IReadOnlyList<GetApprovedArticleCommentsResponse>> Handle(GetApprovedArticleCommentsQuery request, CancellationToken cancellationToken)
    {
        var comments = await _articleRepository.GetApprovedArticleCommentsAsync(request.ArticleId, cancellationToken);
        return comments.Adapt<IReadOnlyList<GetApprovedArticleCommentsResponse>>();
    }
}
