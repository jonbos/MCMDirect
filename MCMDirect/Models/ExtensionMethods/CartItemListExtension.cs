using System.Linq;
using System.Collections.Generic;
using MCMDirect.Models.DomainModel;
using MCMDirect.Models.DTOs;

namespace MCMDirect.Models.ExtensionMethods {
    public static class CartItemListExtension {
        public static List<CartItemDto> ToDTO(this List<CartItem> list) =>
            list.Select(ci => new CartItemDto
            {
                ProductId = ci.Product.ProductID,
                Quantity = ci.Quantity
            }).ToList();
    }
}