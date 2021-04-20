using Microsoft.EntityFrameworkCore.Migrations;

namespace MCMDirect.Migrations
{
    public partial class ImgUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "Image",
                value: "cat_chair.jpeg");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "Image",
                value: "cat_sofa.jpeg");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "Image",
                value: "cat_console.jpeg");

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

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "Image",
                value: "prod_670.jpeg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "Image",
                value: "prod_barcelona_couch.jpeg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                column: "Image",
                value: "prod_line_console.jpeg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "Image",
                value: "~/images/cat_chair.jpeg");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "Image",
                value: "~/images/cat_sofa.jpeg");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "Image",
                value: "~/images/cat_console.jpeg");

            migrationBuilder.UpdateData(
                table: "Manufacturer",
                keyColumn: "ManufacturerId",
                keyValue: 1,
                column: "Image",
                value: "~/images/logo_hm.jpeg");

            migrationBuilder.UpdateData(
                table: "Manufacturer",
                keyColumn: "ManufacturerId",
                keyValue: 2,
                column: "Image",
                value: "~/images/logo_knoll.png");

            migrationBuilder.UpdateData(
                table: "Manufacturer",
                keyColumn: "ManufacturerId",
                keyValue: 3,
                column: "Image",
                value: "~/images/logo_dwr.jpeg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "Image",
                value: "~/images/prod_670.jpeg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "Image",
                value: "~/images/prod_barcelona_couch.jpeg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                column: "Image",
                value: "~/images/prod_line_console.jpeg");
        }
    }
}
