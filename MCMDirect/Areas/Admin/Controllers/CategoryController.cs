using System.Linq;
using MCMDirect.Areas.Store.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MCMDirect.Areas.Admin.Controllers {
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller {
        private MCMContext _context;

        public CategoryController(MCMContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var data = _context.Category.Include(category => category.Products).ToList();
            return View(data);
        }
    }
}