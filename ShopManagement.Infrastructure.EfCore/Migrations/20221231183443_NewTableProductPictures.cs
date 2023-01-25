using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopManagement.Infrastructure.EfCore.Migrations
{
    public partial class NewTableProductPictures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductPicture",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PictureAlt = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PictureTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPicture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductPicture_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductPicture_ProductId",
                table: "ProductPicture",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductPicture");
        }
    }
}
