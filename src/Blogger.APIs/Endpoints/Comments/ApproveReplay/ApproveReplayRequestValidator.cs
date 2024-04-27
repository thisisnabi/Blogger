namespace Blogger.APIs.Endpoints.Comments.ApproveReplay;

public class ApproveReplayRequestValidator : AbstractValidator<ApproveReplayRequest>
{
    public ApproveReplayRequestValidator()
    {
        RuleFor(x => x.CommentId)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.Link)
            .NotEmpty()
            .NotNull();
    }
}