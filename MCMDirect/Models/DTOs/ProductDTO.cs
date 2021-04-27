using MCMDirect.Areas.Store.Models;

namespace MCMDirect.Models.DTOs {
    public class ProductDTO {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public void Load(Product product)
        {
            ProductID = product.ProductId;
            Name = product.Name;
            Price = product.Price;
        }
    }
}