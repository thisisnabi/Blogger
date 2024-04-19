namespace Blogger.APIs.Contracts.PublishDraft;

public class PublishDraftRequestValidator : AbstractValidator<PublishDraftRequest>
{
    public PublishDraftRequestValidator()
    {
        RuleFor(x => x.DraftId)
            .NotEmpty()
            .NotNull();
    }
}