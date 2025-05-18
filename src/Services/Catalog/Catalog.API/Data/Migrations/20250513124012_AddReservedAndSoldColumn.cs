using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catalog.API.Migrations
{
    public partial class AddReservedAndSoldColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isReserved",
                table: "Plates",
                newName: "Sold");

            migrationBuilder.AddColumn<bool>(
                name: "Reserved",
                table: "Plates",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reserved",
                table: "Plates");

            migrationBuilder.RenameColumn(
                name: "Sold",
                table: "Plates",
                newName: "isReserved");
        }
    }
}
