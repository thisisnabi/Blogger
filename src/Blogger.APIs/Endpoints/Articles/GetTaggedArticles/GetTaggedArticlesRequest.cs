namespace Blogger.APIs.Endpoints.Articles.GetTaggedArticles;

public record GetTaggedArticlesRequest([FromQuery] string Tag);
