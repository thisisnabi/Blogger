namespace Blogger.APIs.Contracts.GetReplaies;

public class GetReplaiesValidator : AbstractValidator<GetReplaiesRequest>
{
    public GetReplaiesValidator()
    {
        RuleFor(x => x.CommentId)
            .NotEmpty()
            .NotNull();
    }
}