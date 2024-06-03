namespace Blogger.Application.Articles.MakeDraft;

public class MakeDraftCommandHandler(IArticleRepository articleRepository)
    : IRequestHandler<MakeDraftCommand, MakeDraftCommandResponse>
{

    public async Task<MakeDraftCommandResponse> Handle(MakeDraftCommand request, CancellationToken cancellationToken)
    {
        var draftId = ArticleId.CreateUniqueId(request.Title);
        if (await articleRepository.HasIdAsync(draftId, cancellationToken))
        {
            throw new DraftAlreadyExistsException(draftId.ToString());
        }

        var draft = Article.CreateDraft(request.Title, request.Body, request.Summary);

        if (request.Tags.Any())
        {
            draft.AddTags(request.Tags);
        }

        articleRepository.Add(draft);
        await articleRepository.SaveChangesAsync(cancellationToken);

        return new MakeDraftCommandResponse(draft.Id);
    }
}
