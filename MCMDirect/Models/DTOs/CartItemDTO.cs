using MCMDirect.Areas.Store.Models;

namespace MCMDirect.Models.DTOs {
    public class CartItemDto {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}