namespace Blogger.Application.Articles;
internal class ArticleService(IArticleRepository articleRepository) : IArticleService
{
    public Task<bool> HasIdAsync(ArticleId articleId, CancellationToken cancellationToken)
    {
        return IsArticleIdValidAsync(articleId, cancellationToken);
    }

    public async Task<bool> IsArticleIdValidAsync(ArticleId articleId, CancellationToken cancellationToken)
    {
        return await articleRepository.GetArticleByIdAsync(articleId, cancellationToken) is not null;
    }
}
