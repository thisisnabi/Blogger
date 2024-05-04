using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blogger.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "blog");

            migrationBuilder.CreateTable(
                name: "Articles",
                schema: "blog",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Author_FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author_Avatar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author_JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "varchar(70)", unicode: false, maxLength: 70, nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Summary = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false),
                    PublishedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ReadOn = table.Column<TimeSpan>(type: "time", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                schema: "blog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Client_FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Client_Email = table.Column<string>(type: "nvarchar(1044)", maxLength: 1044, nullable: false),
                    ApproveLink_ApproveId = table.Column<string>(type: "nvarchar(2077)", maxLength: 2077, nullable: false),
                    ApproveLink_ApproveExpirationOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArticleId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Content = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subscribers",
                schema: "blog",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    JoinedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscribers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArticleCommentIds",
                schema: "blog",
                columns: table => new
                {
                    ArticleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleCommentIds", x => new { x.ArticleId, x.Id });
                    table.ForeignKey(
                        name: "FK_ArticleCommentIds_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalSchema: "blog",
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                schema: "blog",
                columns: table => new
                {
                    ArticleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => new { x.ArticleId, x.Id });
                    table.ForeignKey(
                        name: "FK_Tags_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalSchema: "blog",
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Replies",
                schema: "blog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Client_FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Client_Email = table.Column<string>(type: "nvarchar(1044)", maxLength: 1044, nullable: false),
                    ApproveLink_ApproveId = table.Column<string>(type: "nvarchar(2077)", maxLength: 2077, nullable: false),
                    ApproveLink_ApproveExpirationOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Content = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    CommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Replies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Replies_Comments_CommentId",
                        column: x => x.CommentId,
                        principalSchema: "blog",
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubscriberArticleIds",
                schema: "blog",
                columns: table => new
                {
                    SubscriberId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriberArticleIds", x => new { x.SubscriberId, x.Id });
                    table.ForeignKey(
                        name: "FK_SubscriberArticleIds_Subscribers_SubscriberId",
                        column: x => x.SubscriberId,
                        principalSchema: "blog",
                        principalTable: "Subscribers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Replies_CommentId",
                schema: "blog",
                table: "Replies",
                column: "CommentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleCommentIds",
                schema: "blog");

            migrationBuilder.DropTable(
                name: "Replies",
                schema: "blog");

            migrationBuilder.DropTable(
                name: "SubscriberArticleIds",
                schema: "blog");

            migrationBuilder.DropTable(
                name: "Tags",
                schema: "blog");

            migrationBuilder.DropTable(
                name: "Comments",
                schema: "blog");

            migrationBuilder.DropTable(
                name: "Subscribers",
                schema: "blog");

            migrationBuilder.DropTable(
                name: "Articles",
                schema: "blog");
        }
    }
}
