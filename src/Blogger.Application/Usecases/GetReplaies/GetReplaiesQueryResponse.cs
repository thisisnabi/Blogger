using Blogger.Domain.CommentAggregate;

namespace Blogger.Application.Usecases.GetReplaies;

public record GetReplaiesQueryResponse(string FullName, DateTime CreatedOnUtc, string Content)
{

    public static explicit operator GetReplaiesQueryResponse(Replay replay)
        => new GetReplaiesQueryResponse(replay.Client.FullName,replay.CreatedOnUtc, replay.Content);
}