using MCMDirect.Areas.Store.Models;
using MCMDirect.Models.DomainModel;
using MCMDirect.Models.DTOs;
using MCMDirect.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MCMDirect.Areas.Admin.Controllers {
    public class CartController : Controller {
        private MCMContext _context { get; set; }
        public CartController(MCMContext ctx) => _context = ctx;

        private Cart GetCart()
        {
            var cart = new Cart(HttpContext);
            cart.Load(_context);
            return cart;
        }

        public ViewResult Index()
        {
            var cart = GetCart();

            var vm = new CartViewModel
            {
                List = cart.List,
                Subtotal = cart.Subtotal,
            };
            return View(vm);
        }

        [HttpPost]
        public RedirectToActionResult Add(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                TempData["message"] = "Unable to add product to cart.";
            }
            else
            {
                var dto = new ProductDTO();
                dto.Load(product);
                CartItem item = new CartItem
                {
                    Product = dto,
                    Quantity = 1 // default value
                };

                Cart cart = GetCart();
                cart.Add(item);
                cart.Save();

                TempData["message"] = $"{product.Name} added to cart";
            }

            return RedirectToAction("Details", "Product", new {id = id});
        }
    }
}