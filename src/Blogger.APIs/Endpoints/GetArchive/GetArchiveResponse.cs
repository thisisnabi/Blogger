namespace Blogger.APIs.Contracts.GetArchive;

public record GetArchiveResponse(
    string Date,
    GetArchiveItemResponse[] Items);

public record GetArchiveItemResponse(string ArticleId, string Title, int Day);