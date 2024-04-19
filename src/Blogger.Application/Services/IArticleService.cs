
namespace Blogger.Application.Services;
public interface IArticleService
{
    Task<bool> IsArticleIdValidAsync(ArticleId articleId, CancellationToken cancellationToken);

    Task<bool> HasIdAsync(ArticleId articleId, CancellationToken cancellationToken);

}
