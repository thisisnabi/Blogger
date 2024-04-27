namespace Blogger.Application.Articles.MakeDraft;

public record MakeDraftCommand(string Title, string Body, string Summary, IReadOnlyList<Tag> Tags)
    : IRequest<MakeDraftCommandResponse>;