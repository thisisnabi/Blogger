using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blogger.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangeForeignKeysName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Slug",
                schema: "blog",
                table: "SubscriberArticleIds",
                newName: "ArticleId");

            migrationBuilder.RenameColumn(
                name: "Value",
                schema: "blog",
                table: "ArticleCommentIds",
                newName: "CommentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ArticleId",
                schema: "blog",
                table: "SubscriberArticleIds",
                newName: "Slug");

            migrationBuilder.RenameColumn(
                name: "CommentId",
                schema: "blog",
                table: "ArticleCommentIds",
                newName: "Value");
        }
    }
}
