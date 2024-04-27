using Blogger.Application.Articles.UpdateDraft;

namespace Blogger.Application.Articles.PublishDraft;

public class PublishDraftCommandHandler(IArticleRepository articleRepository)
    : IRequestHandler<PublishDraftCommand>
{
    public async Task Handle(PublishDraftCommand request, CancellationToken cancellationToken)
    {
        var draft = await articleRepository.GetDraftByIdAsync(request.DraftId, cancellationToken);
        if (draft is null) throw new DraftNotFoundException();

        draft.Publish();

        await articleRepository.SaveChangesAsync(cancellationToken);

        // TODO: send article nutify for subscriber
    }
}
