namespace MCMDirect.Areas.Store.Models {
    public class Product {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }

        public Manufacturer Manufacturer { get; set; }
        public int ManufacturerId { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}