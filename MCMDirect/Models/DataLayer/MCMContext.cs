using MCMDirect.Areas.Store.Models.SeedData;
using Microsoft.EntityFrameworkCore;

namespace MCMDirect.Areas.Store.Models {
    public class MCMContext : DbContext {
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed initial data
            modelBuilder.ApplyConfiguration(new SeedProduct());
        }
    }
}