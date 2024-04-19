namespace Blogger.APIs.Contracts.ApproveComment;

public class ApproveCommentRequestValidator : AbstractValidator<ApproveCommentRequest>
{
    public ApproveCommentRequestValidator()
    {
        RuleFor(x => x.Link)
            .NotEmpty()
            .NotNull();
    }
}