using Blogger.Application.Usecases.MakeComment;

namespace Blogger.Application.Usecases.ReplayToComment;

public class ReplayToCommentCommandHandler(
    IArticleRepository articleRepository) : IRequestHandler<ReplayToCommentCommand>
{
    private readonly IArticleRepository _articleRepository = articleRepository;
    public async Task Handle(ReplayToCommentCommand request, CancellationToken cancellationToken)
    {
        var article = await _articleRepository.GetArticleByCommentIdAsync(request.CommentId, cancellationToken);

        if (article is null) throw new NotFoundArticleException();

        var replayComment = CommentReplay.Create(request.Client, request.content);
        article.ReplayComment(request.CommentId, replayComment);

        await _articleRepository.SaveChangesAsync(cancellationToken);
    }
}
