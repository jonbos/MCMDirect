using Microsoft.EntityFrameworkCore.Migrations;

namespace MCMDirect.Migrations
{
    public partial class AddManufacturerAddCategoryAddProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturer",
                columns: table => new
                {
                    ManufacturerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Image = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturer", x => x.ManufacturerId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Image = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    ManufacturerId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Manufacturer_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturer",
                        principalColumn: "ManufacturerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 1, "Chairs" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 2, "Sofas" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 3, "Media Units" });

            migrationBuilder.InsertData(
                table: "Manufacturer",
                columns: new[] { "ManufacturerId", "Description", "Image", "Name" },
                values: new object[] { 1, "Keeping it honest Herman Miller is a West Michigan-based company founded with a steadfast belief in bringing integrity to design. This extends to the authorship, materials, craftsmanship, and longevity of its furniture, some of which is part of museum collections worldwide.", "herman_miller.png", "Herman Miller" });

            migrationBuilder.InsertData(
                table: "Manufacturer",
                columns: new[] { "ManufacturerId", "Description", "Image", "Name" },
                values: new object[] { 2, "Timeless American modernism Knoll is a design and manufacturing company that has been producing the work of Eero Saarinen, Marcel Breuer, Warren Platner and others since being founded by Hans Knoll and later run by Florence Knoll. More than 40 Knoll products are in the permanent collection at MoMA.", "knoll.png", "Knoll" });

            migrationBuilder.InsertData(
                table: "Manufacturer",
                columns: new[] { "ManufacturerId", "Description", "Image", "Name" },
                values: new object[] { 3, "Authentic modern design “Our name embodies the mission of our company: to make well-designed products easily accessible to design-savvy professionals.” That was the first sentence in the first DWR catalog, which landed in mailboxes July 4, 1999.", "dwr.png", "Design Within Reach" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Image", "ManufacturerId", "Name", "Price" },
                values: new object[] { 1, 1, "Charles and Ray Eames had ideas about making a better world, one in which things were designed to bring greater pleasure to our lives. Their iconic Eames Lounge Chair and Ottoman (1956) began with a desire to create a chair with “the warm, receptive look of a well-used first baseman’s mitt.” The result embodies what it really means to lounge. In continuous production since its introduction, this set is widely considered one of the most significant designs of the 20th century. Combining soft, inviting leather or mohair with the sleek form of molded wood, the Eames Lounge Chair and Ottoman is the culmination of the Eameses’ efforts to create a club chair using the molded plywood technology they pioneered in the ’40s. Even today, each piece is assembled by hand to ensure the highest level of quality and craftsmanship, and you’ll be pleased to discover the set gets even better with use and age. Cushions snap in and can be removed and changed. This is the authentic Eames Lounge Chair and Ottoman by Herman Miller.", "chair.png", 1, "Eames Lounge and Ottoman", 8249.9899999999998 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Image", "ManufacturerId", "Name", "Price" },
                values: new object[] { 2, 2, "The Barcelona Couch (1930) by Ludwig Mies van der Rohe continues to endure as an icon of modernism and master craft. It’s upholstered using a single Spinneybeck cowhide and supported by an African mahogany sapele hardwood frame and stainless steel legs. To create the deep, precise tufting, individual panels of leather are cut, hand-welted and hand-tufted. The Barcelona Couch is a registered trademark of Knoll, Inc., this is the authentic Barcelona Couch by Knoll. Made in U.S.A.", "barcelona.png", 2, "Barcelona Couch", 10999.99 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Image", "ManufacturerId", "Name", "Price" },
                values: new object[] { 3, 3, "A customer favorite since its debut, the Line Collection features geometric frames made out of precisely crafted oak or walnut. It's distinguished by its strong horizontal lines that reflect natural landscapes and lend a sense of restfulness and calm. On the Line Media Console (2010), this eye-catching louvered design also serves a purpose, allowing remotes to control devices inside. Its roomy, well-organized interior brings order to electronics, routers, albums, books and anything else that needs a home. Working from his studio in Singapore, designer Nathan Yong designs thoughtful pieces that resonate with a quiet elegance, for which he credits the congestion of city living. “My work is a reflection of my yearning for nature in this concrete jungle,” he says. Made in Malaysia.", "line_console.png", 3, "Line Console", 3295.9899999999998 });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ManufacturerId",
                table: "Products",
                column: "ManufacturerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Manufacturer");
        }
    }
}
