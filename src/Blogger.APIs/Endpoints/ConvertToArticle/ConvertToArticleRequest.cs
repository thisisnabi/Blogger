namespace Blogger.APIs.Contracts.ConvertToArticle;

public record ConvertToArticleRequest([FromRoute]string DraftId);
