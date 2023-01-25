using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiscountManagement.Infrastructure.EfCore.Migrations
{
    public partial class NewTableOccasionalDiscount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OccasionalDiscounts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OccasionalDiscounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OccasionalDiscountsProduct",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    OccasionalDiscountsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OccasionalDiscountsProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OccasionalDiscountsProduct_OccasionalDiscounts_OccasionalDiscountsId",
                        column: x => x.OccasionalDiscountsId,
                        principalTable: "OccasionalDiscounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OccasionalDiscountsProduct_OccasionalDiscountsId",
                table: "OccasionalDiscountsProduct",
                column: "OccasionalDiscountsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OccasionalDiscountsProduct");

            migrationBuilder.DropTable(
                name: "OccasionalDiscounts");
        }
    }
}
