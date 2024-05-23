namespace Blogger.Infrastructure.Persistence;
public static class BloggerDbContextSchema
{
    public const string DefaultSchema = "blog";
    public const string DefaultConnectionStringName = "SvcDbContext";

    public static class SubscriberDbSchema
    {
        public const string TableName = "Subscribers";
        public const string ArticleIdTableName = "SubscriberArticleIds";
        public const string ArticleIdBackendField = "_articleIds";
    }

    public static class ArticleDbSchema
    { 
        public const string TableName = "Articles";
        public const string ForeignKey = "ArticleId";
        public const string CommentIdTableName = "ArticleCommentIds";
        public const string TagTableName = "Tags";
        public const string CommentIdBackendField = "_commentIds";
        public const string TagIdBackendField = "_tags";
        public const string AuthorAvatar = "Author_Avatar";
        public const string AuthorJobTitle = "Author_JobTitle";
        public const string AuthorFullName = "Author_FullName";
    }


    public static class CommentDbSchema
    { 
        public const string TableName = "Comments";
        public const string ForeignKey = "CommentId";
        public const string RepliesTableName = "Replies";
        public const string RepliesBackendField = "_replies";
        public const string ClientFullName = "Client_FullName";
        public const string ClientEmail = "Client_Email";
        public const string ApproveLinkApproveId = "ApproveLink_ApproveId";
        public const string ApproveLinkExpirationOnUtc = "ApproveLink_ApproveExpirationOnUtc";
        public const string ArticleId = "ArticleId";
    }
}