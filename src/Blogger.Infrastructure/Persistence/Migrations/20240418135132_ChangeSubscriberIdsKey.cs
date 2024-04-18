using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blogger.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangeSubscriberIdsKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SubscriberArticleIds",
                schema: "blog",
                table: "SubscriberArticleIds");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "blog",
                table: "SubscriberArticleIds");

            migrationBuilder.AlterColumn<string>(
                name: "Slug",
                schema: "blog",
                table: "SubscriberArticleIds",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubscriberArticleIds",
                schema: "blog",
                table: "SubscriberArticleIds",
                column: "Slug");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriberArticleIds_SubscriberId",
                schema: "blog",
                table: "SubscriberArticleIds",
                column: "SubscriberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SubscriberArticleIds",
                schema: "blog",
                table: "SubscriberArticleIds");

            migrationBuilder.DropIndex(
                name: "IX_SubscriberArticleIds_SubscriberId",
                schema: "blog",
                table: "SubscriberArticleIds");

            migrationBuilder.AlterColumn<string>(
                name: "Slug",
                schema: "blog",
                table: "SubscriberArticleIds",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                schema: "blog",
                table: "SubscriberArticleIds",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubscriberArticleIds",
                schema: "blog",
                table: "SubscriberArticleIds",
                columns: new[] { "SubscriberId", "Id" });
        }
    }
}
