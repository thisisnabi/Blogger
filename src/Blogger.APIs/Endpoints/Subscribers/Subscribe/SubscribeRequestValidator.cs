namespace Blogger.APIs.Endpoints.Subscribers.Subscribe;

public class SubscribeRequestValidator : AbstractValidator<SubscribeRequest>
{
    public SubscribeRequestValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .NotNull();
    }
}