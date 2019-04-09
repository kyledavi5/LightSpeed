using Microsoft.EntityFrameworkCore.Migrations;

namespace LightSpeed.Data.Migrations
{
    public partial class additionalCustomerInfo2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Zip",
                table: "Customers",
                newName: "ZipCode");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Customers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "ZipCode",
                table: "Customers",
                newName: "Zip");
        }
    }
}
