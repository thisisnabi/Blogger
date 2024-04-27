namespace Blogger.APIs.Endpoints.Comments.ApproveComment;

public class ApproveCommentRequestValidator : AbstractValidator<ApproveCommentRequest>
{
    public ApproveCommentRequestValidator()
    {
        RuleFor(x => x.Link)
            .NotEmpty()
            .NotNull();
    }
}