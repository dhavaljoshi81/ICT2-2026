using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ICT2InventoryManagementMVCCoreWebAPPCS.Models;

namespace ICT2InventoryManagementMVCCoreWebAPPCS.Controllers
{
    public class ProductsController : Controller
    {
        private readonly Ict2inventoryManagementDbContext _context;

        public ProductsController(Ict2inventoryManagementDbContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var ict2inventoryManagementDbContext = 
                _context.Products.Include(p => p.CategoryNavigation);
            return View(await ict2inventoryManagementDbContext.ToListAsync());
        }

        
        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.CategoryNavigation)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["Category"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductName,Rate,Category,Description")] Product product)
        {
            //product.CategoryNavigation = _context.Categories
            //    .FirstOrDefault(c => c.CategoryId == product.Category);
           
            //_context.Categories
            //    .FirstOrDefault(c => c.CategoryId == product.Category)?.Products.Add(product);
            
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Category"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", product.Category);
            return View(product);
        }

        // GET: Products/Edit/5
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
            ViewData["Category"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", product.Category);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductName,Rate,Category,Description")] Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
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
            ViewData["Category"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", product.Category);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.CategoryNavigation)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }

        public IActionResult SearchByName()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SearchByName(string ProductName)
        {
            var products = _context.Products
                .Where(p => p.ProductName.Contains(ProductName))
                .Include(p => p.CategoryNavigation)
                .ToList();
            return View("SearchResult", products.ToList());
        }
        
        // GET: Products/SearchResult
        public IActionResult SearchResult(List<Product> productList)
        {
            return View(productList.ToList());
        }

        public IActionResult SearchByRate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SearchByRate(int minRate, int maxRate)
        {
            var products = _context.Products
                .Where(p => p.Rate >= minRate)
                .Where(p => p.Rate <= maxRate)
                .Include(p => p.CategoryNavigation)
                .ToList();
            return View("SearchResult", products.ToList());
        }


    }
}
