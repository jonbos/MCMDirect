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
                    CategoryName = "Chairs"
                },
                new Category
                {
                    CategoryId = 2,
                    CategoryName = "Sofas"
                },
                new Category
                {
                    CategoryId = 3,
                    CategoryName = "Media Units"
                }
            );
        }
    }
}