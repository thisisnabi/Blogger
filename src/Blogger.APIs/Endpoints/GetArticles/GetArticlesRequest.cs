namespace Blogger.APIs.Contracts.GetArticles;

public record GetArticlesRequest([FromQuery] int Page = 1, [FromQuery] int Size = 10);
