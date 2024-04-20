namespace Blogger.APIs.Contracts.GetApprovedArticleComments;

public class GetApprovedArticleCommentsValidator : AbstractValidator<GetApprovedArticleCommentsRequest>
{
    public GetApprovedArticleCommentsValidator()
    {
        RuleFor(x => x.ArticleId)
            .NotEmpty()
            .NotNull();
    }
}