using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MCMDirect.Areas.Admin.Models.ViewModels;
using MCMDirect.Areas.Store.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MCMDirect.Areas.Admin.Models.ExtensionMethods;
using MCMDirect.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace MCMDirect.Areas {
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller {
        private readonly MCMContext _context;
        private readonly IHostingEnvironment _hostEnvironment;
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(MCMContext context, IHostingEnvironment hostEnvironment,
            ILogger<CategoryController> logger)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
            _logger = logger;
        }

        // GET: Category
        public async Task<IActionResult> Index()
        {
            return View(await _context.Category.ToListAsync());
        }

        // GET: Category/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Category
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }


        // GET: Category/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryViewModel vm)
        {
            if (ModelState.IsValid)
            {
                // Handle Image
                if (vm.Image != null)
                {
                    vm.Category.Image = ImageExtensionMethods.UploadFile(vm.Image,
                        Path.Combine(_hostEnvironment.WebRootPath, "images"));
                }

                _context.Add(vm.Category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(vm);
        }

        // GET: Category/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Category.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            CategoryViewModel vm = new CategoryViewModel
            {
                Image = ImageExtensionMethods.ReadImageFile(Path.Combine(_hostEnvironment.WebRootPath, "images",
                    category.Image)),
                Category = category
            };


            return View(vm);
        }

        // POST: Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            CategoryViewModel model)
        {
            if (id != model.Category.CategoryId)
            {
                return NotFound();
            }

            ModelState.Remove("Image");
            if (ModelState.IsValid)
            {
                try
                {
                    // Handle Image
                    if (model.Image != null)
                    {
                        model.Category.Image = ImageExtensionMethods.UploadFile(model.Image,
                            Path.Combine(_hostEnvironment.WebRootPath, "images"));
                    }

                    _context.Update(model.Category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(model.Category.CategoryId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: Category/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Category
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.Category.FindAsync(id);
            _context.Category.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            return _context.Category.Any(e => e.CategoryId == id);
        }
    }
}