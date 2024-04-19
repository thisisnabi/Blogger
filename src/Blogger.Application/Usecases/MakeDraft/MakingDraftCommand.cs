namespace Blogger.Application.Usecases.MakeDraft;

public record MakeDraftCommand(string Title, string Body, string Summary, IReadOnlyList<Tag> Tags) 
    : IRequest<MakeDraftCommandResponse>;