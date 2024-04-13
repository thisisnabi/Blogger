namespace Blogger.Application.Usecases.MakeDraft;

public record MakeDraftCommand(string title, string body, string summary, IReadOnlyList<Tag> Tags) 
    : IRequest<MakeDraftCommandResponse>;