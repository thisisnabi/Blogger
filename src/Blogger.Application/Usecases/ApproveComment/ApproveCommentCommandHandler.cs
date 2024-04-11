namespace Blogger.Application.Usecases.ApproveComment;
public class ApproveCommentCommandHandler(IArticleRepository articleRepository) : IRequestHandler<ApproveCommentCommand>
{
    private readonly IArticleRepository _articleRepository = articleRepository;

    public async Task Handle(ApproveCommentCommand request, CancellationToken cancellationToken)
    {
        var article = await _articleRepository.GetArticleByCommentId(request.CommentId);

        article.ApproveComment(request.CommentId);

        await _articleRepository.SaveChangesAsync(cancellationToken);
    }
}
