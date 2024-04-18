using Blogger.Application.Usecases.CreateArticle;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blogger.APIs.Contracts.CreateArticle;

public static class CreateArticleEndPoint
{
    public static async Task<CreateArticleResponse> CreateArticle([FromBody] CreateArticleRequest request,
                           [FromServices] IMapper mapper,
                           [FromServices] IMediator mediator)
    {

        var command = mapper.Map<CreateArticleCommand>(request);
        var response = await mediator.Send(command);

        return mapper.Map<CreateArticleResponse>(response);
    }
}
