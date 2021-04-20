using Microsoft.AspNetCore.Mvc;

namespace MCMDirect.Controllers {
    public class CategoryController : Controller {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}