using Blogger.Domain.ClientAggregate;

namespace Blogger.Application.Usecases.MakeComment;
public class MakeCommentCommandHandler(
    IArticleRepository articleRepository) : IRequestHandler<MakeCommentCommand>
{
    private readonly IArticleRepository _articleRepository = articleRepository;
    public async Task Handle(MakeCommentCommand request, CancellationToken cancellationToken)
    {
        var article = await _articleRepository.GetArticleById(request.ArticleId, cancellationToken);

        if (article is null) throw new NotFoundArticleException();

        var comment = Comment.Create(request.Client, request.content);
        article.AddComment(comment);

        await _articleRepository.SaveChangesAsync(cancellationToken);
    }
}
