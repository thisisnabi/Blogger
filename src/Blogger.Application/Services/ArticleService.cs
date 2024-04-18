namespace Blogger.Application.Services;
internal class ArticleService(IArticleRepository articleRepository): IArticleService
{
    public async Task<bool> IsArticleIdValidAsync(ArticleId articleId, CancellationToken cancellationToken)
    {
        return (await articleRepository.GetArticleByIdAsync(articleId, cancellationToken)) is not null;
    }
}
