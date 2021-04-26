using System.Linq;
using MCMDirect.Areas.Store.Models;
using MCMDirect.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MCMDirect.Controllers {
    public class CategoryController : Controller {
        private MCMContext _context;
        private readonly ILogger<Areas.CategoryController> _logger;

        public CategoryController(MCMContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var data = _context.Category.ToList();
            _logger.Log(LogLevel.Information, "Getting Category List");

            return View(data);
        }

        public IActionResult Details(int id)
        {
            var vm = new CategoryListViewModel
            {
                Category = _context.Category.Find(id),
                Products = _context.Products.Where(product => product.CategoryId == id)
                    .Include(product => product.Manufacturer)
            };
            _logger.Log(LogLevel.Information, "Getting details page for Category ID: " + id);

            return View(vm);
        }
    }
}