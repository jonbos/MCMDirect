using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MCMDirect.Areas.Admin.Models.ExtensionMethods;
using MCMDirect.Areas.Admin.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MCMDirect.Areas.Store.Models;
using MCMDirect.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace MCMDirect.Areas.Admin.Controllers {
    [Area("Admin")]
    public class ProductController : Controller {
        private readonly MCMContext _context;
        private readonly IHostingEnvironment _hostEnvironment;
        private readonly ILogger<ProductController> _logger;

        public ProductController(MCMContext context, IHostingEnvironment hostEnvironment,
            ILogger<ProductController> logger)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
            _logger = logger;
        }

        // GET: Admin/Product
        public async Task<IActionResult> Index()
        {
            var mCMContext = _context.Products.Include(p => p.Category).Include(p => p.Manufacturer);
            return View(mCMContext.ToList());
        }

        // GET: Admin/Product/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Manufacturer)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Admin/Product/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName");
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturer, "ManufacturerId", "Name");
            return View();
        }

        // POST: Admin/Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            ProductViewModel vm)
        {
            if (ModelState.IsValid)
            {
                // Handle Image
                if (vm.Image != null)
                {
                    vm.Product.Image = ImageExtensionMethods.UploadFile(vm.Image,
                        Path.Combine(_hostEnvironment.WebRootPath, "images"));
                }

                _context.Add(vm.Product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["CategoryId"] =
                new SelectList(_context.Category, "CategoryId", "CategoryName", vm.Product.CategoryId);
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturer, "ManufacturerId", "ManufacturerId",
                vm.Product.ManufacturerId);
            return View(vm);
        }

        // GET: Admin/Product/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            ProductViewModel vm = new ProductViewModel
            {
                Product = product,
                Image = ImageExtensionMethods.ReadImageFile(Path.Combine(_hostEnvironment.WebRootPath, "images",
                    product.Image))
            };

            ViewData["CategoryId"] =
                new SelectList(_context.Category, "CategoryId", "CategoryName", product.CategoryId);
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturer, "ManufacturerId", "Name",
                product.ManufacturerId);
            return View(vm);
        }

        // POST: Admin/Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            ProductViewModel model)
        {
            if (id != model.Product.ProductId)
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
                        model.Product.Image = ImageExtensionMethods.UploadFile(model.Image,
                            Path.Combine(_hostEnvironment.WebRootPath, "images"));
                    }

                    _context.Update(model.Product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(model.Product.ProductId))
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

            ViewData["CategoryId"] =
                new SelectList(_context.Category, "CategoryId", "CategoryName", model.Product.CategoryId);
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturer, "ManufacturerId", "ManufacturerId",
                model.Product.ManufacturerId);
            return View(model);
        }

        // GET: Admin/Product/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Manufacturer)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Admin/Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}