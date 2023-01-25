using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopManagement.Infrastructure.EfCore.Migrations
{
    public partial class NewTableCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PictureAlt = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    PictureTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MetaDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Keywords = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupingId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Grouping_GroupingId",
                        column: x => x.GroupingId,
                        principalTable: "Grouping",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_GroupingId",
                table: "Category",
                column: "GroupingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
