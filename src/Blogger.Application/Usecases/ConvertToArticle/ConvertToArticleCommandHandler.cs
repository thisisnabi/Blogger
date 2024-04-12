using Blogger.Application.Usecases.UpdateDraft;

namespace Blogger.Application.Usecases.ConvertToArticle;

public class ConvertToArticleCommandHandler(IArticleRepository articleRepository) : IRequestHandler<ConvertToArticleCommand>
{
    private readonly IArticleRepository _articleRepository = articleRepository;

    public async Task Handle(ConvertToArticleCommand request, CancellationToken cancellationToken)
    {
        var draft = await _articleRepository.GetDraftById(request.ArticleId, cancellationToken);

        if (draft is null) throw new NotFoundDraftException();

        draft.ConvertToArticle();

        await _articleRepository.SaveChangesAsync(cancellationToken);
    }
}
