using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INVENTORY.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Addrollcolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Roll",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TerritoryManagerId",
                table: "Territories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Roll",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "TerritoryManagerId",
                table: "Territories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
