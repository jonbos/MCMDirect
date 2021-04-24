using MCMDirect.Areas.Store.Models;
using Microsoft.AspNetCore.Mvc;

namespace MCMDirect.Controllers {
    public class ProductController : Controller {
        private MCMContext _context;

        public ProductController(MCMContext context)
        {
            _context = context;
        }

        public IActionResult Details(int id)
        {
            var p = _context.Products.Find(id);
            return View(p);
        }
    }
}