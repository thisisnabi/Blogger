namespace Blogger.APIs.Endpoints.Articles.GetArticle;

public class GetArticleRequestValidator : AbstractValidator<GetArticleRequest>
{
    public GetArticleRequestValidator()
    {
        RuleFor(x => x.ArticleId)
            .NotEmpty()
            .NotNull();
    }
}