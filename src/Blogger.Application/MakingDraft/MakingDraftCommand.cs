namespace Blogger.Application.MakingDraft;

public record MakingDraftCommand(string title,string body, string summery, string[] Tags) 
    : IRequest<MakingDraftCommandResponse>;