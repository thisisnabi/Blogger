namespace Blogger.APIs.Contracts.ConvertToArticle;

public class ConvertToArticleRequestValidator : AbstractValidator<ConvertToArticleRequest>
{
    public ConvertToArticleRequestValidator()
    {
        RuleFor(x => x.DraftId)
            .NotEmpty()
            .NotNull();
    }
}