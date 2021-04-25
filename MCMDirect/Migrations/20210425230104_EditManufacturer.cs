using Microsoft.EntityFrameworkCore.Migrations;

namespace MCMDirect.Migrations
{
    public partial class EditManufacturer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Manufacturer");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryName",
                table: "Category",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Manufacturer",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CategoryName",
                table: "Category",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.UpdateData(
                table: "Manufacturer",
                keyColumn: "ManufacturerId",
                keyValue: 1,
                column: "Image",
                value: "logo_hm.jpeg");

            migrationBuilder.UpdateData(
                table: "Manufacturer",
                keyColumn: "ManufacturerId",
                keyValue: 2,
                column: "Image",
                value: "logo_knoll.png");

            migrationBuilder.UpdateData(
                table: "Manufacturer",
                keyColumn: "ManufacturerId",
                keyValue: 3,
                column: "Image",
                value: "logo_dwr.jpeg");
        }
    }
}
