using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CommentManagement.Infrstructure.EfCore.Migrations
{
    public partial class NewTableCommentScore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommentScore",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountId = table.Column<long>(type: "bigint", nullable: false),
                    IsRemove = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentScore", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommentScoreOption",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Operation = table.Column<bool>(type: "bit", nullable: false),
                    CommentScoreId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentScoreOption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentScoreOption_CommentScore_CommentScoreId",
                        column: x => x.CommentScoreId,
                        principalTable: "CommentScore",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentScoreOption_CommentScoreId",
                table: "CommentScoreOption",
                column: "CommentScoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentScoreOption");

            migrationBuilder.DropTable(
                name: "CommentScore");
        }
    }
}
