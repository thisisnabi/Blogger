namespace Blogger.APIs.Endpoints.Comments.ApproveReply;

public class ApproveReplyRequestValidator : AbstractValidator<ApproveReplyRequest>
{
    public ApproveReplyRequestValidator()
    {
        RuleFor(x => x.CommentId)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.Link)
            .NotEmpty()
            .NotNull();
    }
}