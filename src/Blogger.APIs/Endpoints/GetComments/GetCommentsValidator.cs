namespace Blogger.APIs.Contracts.GetComments;

public class GetCommentsValidator : AbstractValidator<GetCommentsRequest>
{
    public GetCommentsValidator()
    {
        RuleFor(x => x.ArticleId)
            .NotEmpty()
            .NotNull();
    }
}