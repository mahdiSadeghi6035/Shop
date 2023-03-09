using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagement.Infrastructure.EfCore.Migrations
{
    public partial class NewTableWarranty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "WarrantyId",
                table: "Inventory",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Warranty",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WarrantyDescription = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warranty", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_WarrantyId",
                table: "Inventory",
                column: "WarrantyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Warranty_WarrantyId",
                table: "Inventory",
                column: "WarrantyId",
                principalTable: "Warranty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Warranty_WarrantyId",
                table: "Inventory");

            migrationBuilder.DropTable(
                name: "Warranty");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_WarrantyId",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "WarrantyId",
                table: "Inventory");
        }
    }
}
