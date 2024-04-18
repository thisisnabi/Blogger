using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blogger.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangeArticleCommandIdsKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                column: "Value");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleCommentIds_ArticleId",
                schema: "blog",
                table: "ArticleCommentIds",
                column: "ArticleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
