using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi_LS1_HW.Migrations
{
    /// <inheritdoc />
    public partial class AddPriceAndDiscountToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Fullname",
                table: "Customers",
                newName: "Surname");

            migrationBuilder.AddColumn<double>(
                name: "Discount",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Customers",
                newName: "Fullname");
        }
    }
}
