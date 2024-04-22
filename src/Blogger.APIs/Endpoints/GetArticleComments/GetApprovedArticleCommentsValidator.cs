namespace Blogger.APIs.Contracts.GetArticleComments;

public class GetApprovedArticleCommentsValidator : AbstractValidator<GetApprovedArticleCommentsRequest>
{
    public GetApprovedArticleCommentsValidator()
    {
        RuleFor(x => x.ArticleId)
            .NotEmpty()
            .NotNull();
    }
}