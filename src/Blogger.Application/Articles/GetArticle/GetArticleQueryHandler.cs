using Blogger.Application.Comments.MakeComment;

namespace Blogger.Application.Articles.GetArticle;

public class GetArticlesQueryHandler(
    IArticleRepository articleRepository) : IRequestHandler<GetArticleQuery, GetArticleQueryResponse>
{
    private readonly IArticleRepository _articleRepository = articleRepository;

    public async Task<GetArticleQueryResponse> Handle(GetArticleQuery request, CancellationToken cancellationToken)
    {
        var article = await _articleRepository.GetArticleByIdAsync(request.ArticleId, cancellationToken);
        if (article is null)
        {
            throw new NotFoundArticleException();
        }

        return (GetArticleQueryResponse)article;
    }
}
