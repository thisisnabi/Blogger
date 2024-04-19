namespace Blogger.APIs.Contracts.ApproveReplay;

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