using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MCMDirect.Areas.Store.Models.SeedData {
    public class SeedCategory : IEntityTypeConfiguration<Category> {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category
                {
                    CategoryId = 1,
                    CategoryName = "Chairs",
                    Image = SeedUtil.ReadFile("wwwroot/images/cat_chair.jpeg")
                },
                new Category
                {
                    CategoryId = 2,
                    CategoryName = "Sofas",
                    Image = SeedUtil.ReadFile("wwwroot/images/cat_sofa.jpeg")
                },
                new Category
                {
                    CategoryId = 3,
                    CategoryName = "Media Units",
                    Image = SeedUtil.ReadFile("wwwroot/images/cat_console.jpeg")
                }
            );
        }
    }
}