namespace Blogger.Application.Usecases.MakeDraft;

public record MakeDraftCommand(string title, string body, string summery, IReadOnlyList<Tag> Tags) : IRequest<MakeDraftCommandResponse>;