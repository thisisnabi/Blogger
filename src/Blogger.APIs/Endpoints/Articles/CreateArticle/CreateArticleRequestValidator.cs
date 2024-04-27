namespace Blogger.APIs.Endpoints.Articles.CreateArticle;

public class CreateArticleRequestValidator : AbstractValidator<CreateArticleRequest>
{
    private const string TagMaximumLengthMessage = "The tags must contain at most 10 elements.";

    public CreateArticleRequestValidator()
    {
        RuleFor(x => x.Title)
            .MaximumLength(70)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.Summary)
            .MaximumLength(300)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.Body)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.Tags)
             .NotEmpty()
             .NotNull()
             .Must(x => x.Length <= 10).WithMessage(TagMaximumLengthMessage);
    }
}