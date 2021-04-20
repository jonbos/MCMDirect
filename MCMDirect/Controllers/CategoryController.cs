using System.Linq;
using MCMDirect.Areas.Store.Models;
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
            
            return View();
        }
    }
}