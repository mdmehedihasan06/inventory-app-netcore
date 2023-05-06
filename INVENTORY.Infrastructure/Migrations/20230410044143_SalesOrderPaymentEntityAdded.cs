using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INVENTORY.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SalesOrderPaymentEntityAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDeletedBy",
                table: "Users",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "IsDeletedBy",
                table: "UnitOfMeasurements",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "IsDeletedBy",
                table: "Territories",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "IsDeletedBy",
                table: "Suppliers",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "IsDeletedBy",
                table: "SalesOrderMaster",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "IsDeletedBy",
                table: "SalesOrderCost",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "IsDeletedBy",
                table: "Regions",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "IsDeletedBy",
                table: "ProductSubCategories",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "IsDeletedBy",
                table: "Products",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "IsDeletedBy",
                table: "ProductModels",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "IsDeletedBy",
                table: "ProductCategories",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "IsDeletedBy",
                table: "ProductBrands",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "IsDeletedBy",
                table: "KamAreaMappings",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "IsDeletedBy",
                table: "Customers",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "IsDeletedBy",
                table: "Areas",
                newName: "DeletedBy");

            migrationBuilder.AddColumn<string>(
                name: "DeviceInfo",
                table: "Users",
                type: "nvarchar(300)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceInfo",
                table: "UnitOfMeasurements",
                type: "nvarchar(300)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceInfo",
                table: "Territories",
                type: "nvarchar(300)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceInfo",
                table: "Suppliers",
                type: "nvarchar(300)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceInfo",
                table: "SalesOrderMaster",
                type: "nvarchar(300)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceInfo",
                table: "SalesOrderDetails",
                type: "nvarchar(300)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SalesOrderMasterId",
                table: "SalesOrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DeviceInfo",
                table: "SalesOrderCost",
                type: "nvarchar(300)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceInfo",
                table: "Regions",
                type: "nvarchar(300)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceInfo",
                table: "ProductSubCategories",
                type: "nvarchar(300)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceInfo",
                table: "Products",
                type: "nvarchar(300)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceInfo",
                table: "ProductModels",
                type: "nvarchar(300)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceInfo",
                table: "ProductCategories",
                type: "nvarchar(300)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceInfo",
                table: "ProductBrands",
                type: "nvarchar(300)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceInfo",
                table: "KamAreaMappings",
                type: "nvarchar(300)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceInfo",
                table: "Customers",
                type: "nvarchar(300)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceInfo",
                table: "Areas",
                type: "nvarchar(300)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderDetails_SalesOrderMasterId",
                table: "SalesOrderDetails",
                column: "SalesOrderMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrderDetails_SalesOrderMaster_SalesOrderMasterId",
                table: "SalesOrderDetails",
                column: "SalesOrderMasterId",
                principalTable: "SalesOrderMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrderDetails_SalesOrderMaster_SalesOrderMasterId",
                table: "SalesOrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_SalesOrderDetails_SalesOrderMasterId",
                table: "SalesOrderDetails");

            migrationBuilder.DropColumn(
                name: "DeviceInfo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DeviceInfo",
                table: "UnitOfMeasurements");

            migrationBuilder.DropColumn(
                name: "DeviceInfo",
                table: "Territories");

            migrationBuilder.DropColumn(
                name: "DeviceInfo",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "DeviceInfo",
                table: "SalesOrderMaster");

            migrationBuilder.DropColumn(
                name: "DeviceInfo",
                table: "SalesOrderDetails");

            migrationBuilder.DropColumn(
                name: "SalesOrderMasterId",
                table: "SalesOrderDetails");

            migrationBuilder.DropColumn(
                name: "DeviceInfo",
                table: "SalesOrderCost");

            migrationBuilder.DropColumn(
                name: "DeviceInfo",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "DeviceInfo",
                table: "ProductSubCategories");

            migrationBuilder.DropColumn(
                name: "DeviceInfo",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DeviceInfo",
                table: "ProductModels");

            migrationBuilder.DropColumn(
                name: "DeviceInfo",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "DeviceInfo",
                table: "ProductBrands");

            migrationBuilder.DropColumn(
                name: "DeviceInfo",
                table: "KamAreaMappings");

            migrationBuilder.DropColumn(
                name: "DeviceInfo",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "DeviceInfo",
                table: "Areas");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "Users",
                newName: "IsDeletedBy");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "UnitOfMeasurements",
                newName: "IsDeletedBy");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "Territories",
                newName: "IsDeletedBy");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "Suppliers",
                newName: "IsDeletedBy");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "SalesOrderMaster",
                newName: "IsDeletedBy");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "SalesOrderCost",
                newName: "IsDeletedBy");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "Regions",
                newName: "IsDeletedBy");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "ProductSubCategories",
                newName: "IsDeletedBy");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "Products",
                newName: "IsDeletedBy");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "ProductModels",
                newName: "IsDeletedBy");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "ProductCategories",
                newName: "IsDeletedBy");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "ProductBrands",
                newName: "IsDeletedBy");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "KamAreaMappings",
                newName: "IsDeletedBy");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "Customers",
                newName: "IsDeletedBy");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "Areas",
                newName: "IsDeletedBy");
        }
    }
}
