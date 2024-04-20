namespace Blogger.APIs.Contracts.MakeDraft;

public class MakeCommentRequestValidator : AbstractValidator<MakeCommentRequest>
{
    private const string TagMaximumLengthMessage = "The tags must contain at most 10 elements.";

    public MakeCommentRequestValidator()
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
             .Must(x => x.Length <= 10).WithMessage(TagMaximumLengthMessage);
    }
}