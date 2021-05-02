using System.Collections.Generic;
using MCMDirect.Models.DomainModel;

namespace MCMDirect.Models.ViewModels {
    public class CartViewModel {
        public IEnumerable<CartItem> List { get; set; }
        public double Subtotal { get; set; }
    }
}