namespace Blogger.APIs.Endpoints.Articles.GetArchive;

public record GetArchiveResponse(
    int Year,
    int Month,
    IReadOnlyList<GetArchiveItemResponse> Articles);

public record GetArchiveItemResponse(string ArticleId, string Title, int Day);