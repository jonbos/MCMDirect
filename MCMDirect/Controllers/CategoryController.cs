using System.Linq;
using MCMDirect.Areas.Store.Models;
using MCMDirect.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MCMDirect.Controllers {
    public class CategoryController : Controller {
        private MCMContext _context;

        public CategoryController(MCMContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var data = _context.Category.ToList();
            return View(data);
        }

        public IActionResult Details(int id)
        {
            var vm = new CategoryListViewModel()
            {
                category = _context.Category.Find(id),
                products = _context.Products.Where(product => product.CategoryId == id)
            };
            return View(vm);
        }
    }
}