using MCMDirect.Areas.Store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MCMDirect.Controllers {
    public class ProductController : Controller {
        private MCMContext _context;
        private readonly ILogger<ProductController> _logger;

        public ProductController(MCMContext context)
        {
            _context = context;
        }

        public IActionResult Details(int id)
        {
            var p = _context.Products.Find(id);
            _logger.Log(LogLevel.Information, "Getting details page for Product ID: " + p.ProductId);
            return View(p);
        }
    }
}