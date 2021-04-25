using MCMDirect.Areas.Store.Models;
using Microsoft.AspNetCore.Mvc;

namespace MCMDirect.Controllers {
    public class CartController : Controller {
        private MCMContext _context { get; set; }

        public CartController(MCMContext context)
        {
            _context = context;
        }

        public IActionResult Add(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}