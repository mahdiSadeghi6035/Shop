using Microsoft.EntityFrameworkCore.Migrations;

namespace DiscountManagement.Infrastructure.EfCore.Migrations
{
    public partial class UpdateTableOccasionalDiscounts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OccasionalDiscountsProduct",
                table: "OccasionalDiscountsProduct");

            migrationBuilder.DropIndex(
                name: "IX_OccasionalDiscountsProduct_OccasionalDiscountsId",
                table: "OccasionalDiscountsProduct");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "OccasionalDiscounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OccasionalDiscountsProduct",
                table: "OccasionalDiscountsProduct",
                columns: new[] { "OccasionalDiscountsId", "Id" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OccasionalDiscountsProduct",
                table: "OccasionalDiscountsProduct");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "OccasionalDiscounts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OccasionalDiscountsProduct",
                table: "OccasionalDiscountsProduct",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_OccasionalDiscountsProduct_OccasionalDiscountsId",
                table: "OccasionalDiscountsProduct",
                column: "OccasionalDiscountsId");
        }
    }
}
