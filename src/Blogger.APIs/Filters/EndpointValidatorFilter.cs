namespace Blogger.APIs.Filters;

public class EndpointValidatorFilter<T> : IEndpointFilter
{
    private readonly IValidator<T> _validator;
    public EndpointValidatorFilter(IValidator<T> validator)
    {
        _validator = validator;
    }

    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        T? inputData = context.GetArgument<T>(0);

        if (inputData is not null)
        {
            var validationResult = await _validator.ValidateAsync(inputData);
            if (!validationResult.IsValid)
            {
                return Results.ValidationProblem(validationResult.ToDictionary(), 
                                                 statusCode: (int)HttpStatusCode.UnprocessableEntity);
            }
        }

        return await next.Invoke(context);
    }
}

public static class ValidatorExtensions
{
    public static RouteHandlerBuilder Validator<T>(this RouteHandlerBuilder handlerBuilder)
        where T : class
    {
        handlerBuilder.AddEndpointFilter<EndpointValidatorFilter<T>>();
        return handlerBuilder;
    }
}