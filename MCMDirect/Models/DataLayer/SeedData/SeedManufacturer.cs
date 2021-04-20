using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MCMDirect.Areas.Store.Models.SeedData {
    public class SeedManufacturer : IEntityTypeConfiguration<Manufacturer> {
        public void Configure(EntityTypeBuilder<Manufacturer> builder)
        {
            builder.HasData(
                new Manufacturer
                {
                    Description =
                        "Keeping it honest Herman Miller is a West Michigan-based company founded with a steadfast belief in bringing integrity to design. This extends to the authorship, materials, craftsmanship, and longevity of its furniture, some of which is part of museum collections worldwide.",
                    Image = SeedUtil.ReadFile("wwwroot/images/logo_hm.jpeg"),
                    Name = "Herman Miller",
                    ManufacturerId = 1
                },
                new Manufacturer
                {
                    Description =
                        "Timeless American modernism Knoll is a design and manufacturing company that has been producing the work of Eero Saarinen, Marcel Breuer, Warren Platner and others since being founded by Hans Knoll and later run by Florence Knoll. More than 40 Knoll products are in the permanent collection at MoMA.",
                    Image = SeedUtil.ReadFile("wwwroot/images/logo_knoll.png"),
                    Name = "Knoll",
                    ManufacturerId = 2
                },
                new Manufacturer
                {
                    Description =
                        "Authentic modern design “Our name embodies the mission of our company: to make well-designed products easily accessible to design-savvy professionals.” That was the first sentence in the first DWR catalog, which landed in mailboxes July 4, 1999.",
                    Image = SeedUtil.ReadFile("wwwroot/images/logo_dwr.jpeg"),
                    Name = "Design Within Reach",
                    ManufacturerId = 3
                }
            );
        }
    }
}