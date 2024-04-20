namespace Blogger.APIs.Contracts.ReplayToCommet;

public class ReplayToCommentRequestValidator : AbstractValidator<ReplayToCommentRequest>
{
    public ReplayToCommentRequestValidator()
    {
        RuleFor(x => x.CommentId)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.Content)
            .MaximumLength(500)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.FullName)
            .MaximumLength(100)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.Email)
            .MaximumLength(1044)
            .NotEmpty()
            .NotNull();
    }
}