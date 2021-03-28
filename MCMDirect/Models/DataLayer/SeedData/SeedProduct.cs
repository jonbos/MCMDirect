using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MCMDirect.Areas.Store.Models.SeedData {
    public class SeedProduct : IEntityTypeConfiguration<Product> {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product
                {
                    Description = "Leather Chair",
                    Image = "chair.png",
                    Name = "Leather Chair",
                    Price = 999.99,
                    ProductId = 1
                },
                new Product
                {
                    Description = "A beautiful coffee table",
                    Image = "coffee_table.png",
                    Name = "Coffee Table",
                    Price = 499.99,
                    ProductId = 2
                },
                new Product
                {
                    Description = "Walnut Credenza",
                    Image = "credenza.png",
                    Name = "Credenza",
                    Price = 1199.99,
                    ProductId = 3
                }
            );
        }
    }
}