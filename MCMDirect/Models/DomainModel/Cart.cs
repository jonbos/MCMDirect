using System.Collections.Generic;
using System.Linq;
using MCMDirect.Areas.Store.Models;
using MCMDirect.Models.DTOs;
using MCMDirect.Models.ExtensionMethods;
using Microsoft.AspNetCore.Http;

namespace MCMDirect.Models.DomainModel {
    public class Cart {
        private const string CartKey = "mycart";
        private const string CountKey = "mycount";

        private List<CartItem> items { get; set; }
        private List<CartItemDto> storedItems { get; set; }

        private ISession session { get; set; }
        private IRequestCookieCollection requestCookies { get; set; }
        private IResponseCookies responseCookies { get; set; }

        public Cart(HttpContext ctx)
        {
            session = ctx.Session;
            requestCookies = ctx.Request.Cookies;
            responseCookies = ctx.Response.Cookies;
        }


        public void Load(MCMContext _context)
        {
            items = session.GetObject<List<CartItem>>(CartKey);
            if (items == null)
            {
                items = new List<CartItem>();
                storedItems = requestCookies.GetObject<List<CartItemDto>>(CartKey);
            }

            if (storedItems?.Count > items?.Count)
            {
                foreach (CartItemDto storedItem in storedItems)
                {
                    var product = _context.Products.Find(storedItem.ProductId);
                    if (product != null)
                    {
                        var dto = new ProductDTO();
                        dto.Load(product);

                        CartItem item = new CartItem
                        {
                            Product = dto,
                            Quantity = storedItem.Quantity
                        };
                        items.Add(item);
                    }
                }

                Save();
            }
        }

        public double Subtotal => items.Sum(i => i.Subtotal);
        public int? Count => session.GetInt32(CountKey) ?? requestCookies.GetInt32(CountKey);
        public IEnumerable<CartItem> List => items;

        public CartItem GetById(int id) =>
            items.FirstOrDefault(ci => ci.Product.ProductID == id);

        public void Add(CartItem item)
        {
            var itemInCart = GetById(item.Product.ProductID);

            if (itemInCart == null)
            {
                items.Add(item);
            }
            else
            {
                itemInCart.Quantity += 1;
            }
        }

        public void Edit(CartItem item)
        {
            var itemInCart = GetById(item.Product.ProductID);
            if (itemInCart != null)
            {
                itemInCart.Quantity = item.Quantity;
            }
        }

        public void Remove(CartItem item) => items.Remove(item);
        public void Clear() => items.Clear();

        public void Save()
        {
            if (items.Count == 0)
            {
                session.Remove(CartKey);
                session.Remove(CountKey);
                responseCookies.Delete(CartKey);
                responseCookies.Delete(CountKey);
            }
            else
            {
                session.SetObject<List<CartItem>>(CartKey, items);
                session.SetInt32(CountKey, items.Count);
                responseCookies.SetObject<List<CartItemDto>>(CartKey, items.ToDTO());
                responseCookies.SetInt32(CountKey, items.Count);
            }
        }
    }
}