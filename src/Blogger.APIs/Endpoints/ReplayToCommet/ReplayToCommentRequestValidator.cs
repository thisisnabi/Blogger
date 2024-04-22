namespace Blogger.APIs.Contracts.ReplayToCommet;

public class ReplayToCommentRequestValidator : AbstractValidator<ReplayToCommentRequestModel>
{
    public ReplayToCommentRequestValidator()
    {
        RuleFor(x => x.CommentId)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.body.Content)
            .MaximumLength(500)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.body.FullName)
            .MaximumLength(100)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.body.Email)
            .MaximumLength(1044)
            .NotEmpty()
            .NotNull();
    }
}