using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MCMDirect.Areas.Store.Models.SeedData {
    public class SeedProduct : IEntityTypeConfiguration<Product> {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product
                {
                    ProductId = 1,
                    Description =
                        "Charles and Ray Eames had ideas about making a better world, one in which things were designed to bring greater pleasure to our lives. Their iconic Eames Lounge Chair and Ottoman (1956) began with a desire to create a chair with “the warm, receptive look of a well-used first baseman’s mitt.” The result embodies what it really means to lounge. In continuous production since its introduction, this set is widely considered one of the most significant designs of the 20th century. Combining soft, inviting leather or mohair with the sleek form of molded wood, the Eames Lounge Chair and Ottoman is the culmination of the Eameses’ efforts to create a club chair using the molded plywood technology they pioneered in the ’40s. Even today, each piece is assembled by hand to ensure the highest level of quality and craftsmanship, and you’ll be pleased to discover the set gets even better with use and age. Cushions snap in and can be removed and changed. This is the authentic Eames Lounge Chair and Ottoman by Herman Miller.",
                    Image = SeedUtil.ReadFile("wwwroot/images/prod_670.jpeg"),
                    Name = "Eames Lounge and Ottoman",
                    Price = 8249.99,
                    ManufacturerId = 1,
                    CategoryId = 1
                },
                new Product
                {
                    ProductId = 2,
                    Description =
                        "The Barcelona Couch (1930) by Ludwig Mies van der Rohe continues to endure as an icon of modernism and master craft. It’s upholstered using a single Spinneybeck cowhide and supported by an African mahogany sapele hardwood frame and stainless steel legs. To create the deep, precise tufting, individual panels of leather are cut, hand-welted and hand-tufted. The Barcelona Couch is a registered trademark of Knoll, Inc., this is the authentic Barcelona Couch by Knoll. Made in U.S.A.",
                    Image = SeedUtil.ReadFile("wwwroot/images/prod_barcelona_couch.jpeg"),
                    Name = "Barcelona Couch",
                    Price = 10999.99,
                    ManufacturerId = 2,
                    CategoryId = 2
                },
                new Product
                {
                    ProductId = 3,
                    Description =
                        "A customer favorite since its debut, the Line Collection features geometric frames made out of precisely crafted oak or walnut. It's distinguished by its strong horizontal lines that reflect natural landscapes and lend a sense of restfulness and calm. On the Line Media Console (2010), this eye-catching louvered design also serves a purpose, allowing remotes to control devices inside. Its roomy, well-organized interior brings order to electronics, routers, albums, books and anything else that needs a home. Working from his studio in Singapore, designer Nathan Yong designs thoughtful pieces that resonate with a quiet elegance, for which he credits the congestion of city living. “My work is a reflection of my yearning for nature in this concrete jungle,” he says. Made in Malaysia.",
                    Image = SeedUtil.ReadFile("wwwroot/images/prod_line_console.jpeg"),
                    Name = "Line Console",
                    Price = 3295.99,
                    ManufacturerId = 3,
                    CategoryId = 3
                }
            );
        }
    }
}