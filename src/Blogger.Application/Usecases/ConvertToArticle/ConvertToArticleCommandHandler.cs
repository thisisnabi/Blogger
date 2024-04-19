namespace Blogger.Application.Usecases.ConvertToArticle;

public class ConvertToArticleCommandHandler(IArticleRepository articleRepository)
    : IRequestHandler<ConvertToArticleCommand>
{
    public async Task Handle(ConvertToArticleCommand request, CancellationToken cancellationToken)
    {
        var draft = await articleRepository.GetDraftByIdAsync(request.DraftId, cancellationToken);
        if (draft is null) throw new DraftNotFoundException();

        draft.ConvertToArticle();

        await articleRepository.SaveChangesAsync(cancellationToken);
    }
}
