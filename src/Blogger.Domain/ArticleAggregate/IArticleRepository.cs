namespace Blogger.Domain.ArticleAggregate;

public interface IArticleRepository
{
    Task<bool> HasIdAsync(ArticleId articleId, CancellationToken cancellationToken);
    void Add(Article article);

    Task<IReadOnlyList<Tag>> GetPopularTagsAsync(int size,CancellationToken cancellationToken);
    Task<IReadOnlyList<Tag>> GetTagsAsync(CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
    void Delete(Article draft);
    Task<Article?> GetDraftByIdAsync(ArticleId draftId, CancellationToken cancellationToken);
    Task<Article?> GetArticleByIdAsync(ArticleId articleId, CancellationToken cancellationToken);
     
    Task<IReadOnlyList<Article>> GetArchiveArticlesAsync(CancellationToken cancellationToken);
    Task<IReadOnlyList<Article>> GetLatestArticlesAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);
    Task<IReadOnlyList<Article>> GetLatestArticlesAsync(Tag tag, CancellationToken cancellationToken);
    Task<IReadOnlyList<Article>> GetPopularArticlesAsync(int size, CancellationToken cancellationToken);
}
