using MCMDirect.Models.DTOs;
using Newtonsoft.Json;

namespace MCMDirect.Models.DomainModel {
    public class CartItem {
        public ProductDTO Product { get; set; }
        public int Quantity { get; set; }

        [JsonIgnore] public double Subtotal => Product.Price * Quantity;
    }
}