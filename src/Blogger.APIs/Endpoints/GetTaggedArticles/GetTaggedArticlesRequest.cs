namespace Blogger.APIs.Contracts.GetTaggedArticles;

public record GetTaggedArticlesRequest([FromQuery] string Tag);
