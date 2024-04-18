using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blogger.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangeForeignKeArticleComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ArticleCommentIds",
                schema: "blog",
                table: "ArticleCommentIds");

            migrationBuilder.DropIndex(
                name: "IX_ArticleCommentIds_ArticleId",
                schema: "blog",
                table: "ArticleCommentIds");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                schema: "blog",
                table: "ArticleCommentIds",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArticleCommentIds",
                schema: "blog",
                table: "ArticleCommentIds",
                columns: new[] { "ArticleId", "Id" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ArticleCommentIds",
                schema: "blog",
                table: "ArticleCommentIds");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "blog",
                table: "ArticleCommentIds");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArticleCommentIds",
                schema: "blog",
                table: "ArticleCommentIds",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleCommentIds_ArticleId",
                schema: "blog",
                table: "ArticleCommentIds",
                column: "ArticleId");
        }
    }
}
