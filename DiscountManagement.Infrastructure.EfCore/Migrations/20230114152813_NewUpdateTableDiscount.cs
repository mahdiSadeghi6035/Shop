using Microsoft.EntityFrameworkCore.Migrations;

namespace DiscountManagement.Infrastructure.EfCore.Migrations
{
    public partial class NewUpdateTableDiscount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreateionDate",
                table: "Discount",
                newName: "CreationDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Discount",
                newName: "CreateionDate");
        }
    }
}
