using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ICT2InventoryManagementWebAPIConsumer.Models;

namespace ICT2InventoryManagementWebAPIConsumer.Controllers
{
    public class ProductsController : Controller
    {
        private readonly HttpClient _httpClient;

        public ProductsController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("InventoryApi");
        }

        // GET: Product (Index with Advanced Search)
        public async Task<IActionResult> Index(string? searchName, int? categoryId, int? minPrice, int? maxPrice)
        {
            //Fetch all products from API
            var products = await _httpClient
                .GetFromJsonAsync<List<Product>>("Products");

            //Fetch categories for the search dropdown
            var categories = await _httpClient
                .GetFromJsonAsync<List<Category>>("Categories");

            if (categories != null && categories.Count != 0)
            {
                ViewBag.Categories = new SelectList(categories,
                           "categoryId", "categoryName");
            }
            else
                ViewBag.CategoryError = "Category data is unavailable.";


            //if (categories.Any())
            //{
            //    ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName", categoryId);
            //}
            //else
            //{
            //    ViewBag.Categories = new SelectList(Enumerable.Empty<SelectListItem>());
            //    ViewBag.CategoryError = "Category data is unavailable.";
            //}


            //Apply advanced search filters (Client-side filtering)
            var filtered = products?.AsQueryable();

            if (filtered != null)
            {
                if (!string.IsNullOrEmpty(searchName))
                    filtered = filtered.Where(p => p.ProductName
                                        .Contains(searchName, 
                                            StringComparison.OrdinalIgnoreCase)
                                        );

                if (categoryId.HasValue)
                    filtered = filtered.Where(p => p.Category == categoryId.Value);

                if (minPrice.HasValue)
                    filtered = filtered.Where(p => p.Rate >= minPrice.Value);

                if (maxPrice.HasValue)
                    filtered = filtered.Where(p => p.Rate <= maxPrice.Value);
            }

            return View(filtered?.ToList());
        }

        // GET: Product/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var product = await _httpClient
                .GetFromJsonAsync<Product>($"Products/{id}");
            
            if (product == null) 
                return NotFound();
            
            return View(product);
        }

        // GET: Product/Create
        public async Task<IActionResult> Create()
        {
            var categories = await _httpClient
                .GetFromJsonAsync<List<Category>>("Categories");
            
            ViewBag.CategoryList = 
                new SelectList(categories, "categoryId", "categoryName");
            
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            product.CategoryNavigation = null; // Avoid circular reference issues
            //if (ModelState.IsValid)
            {
                var response = await _httpClient
                    .PostAsJsonAsync("Products", product);
                
                if (response.IsSuccessStatusCode) 
                    return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _httpClient
                .GetFromJsonAsync<Product>($"Products/{id}");
            
            if (product == null) 
                return NotFound();

            var categories = await _httpClient
                              .GetFromJsonAsync<List<Category>>("Categories");
            
            ViewBag.CategoryList = 
                new SelectList(categories, "categoryId", "categoryName", product.Category);

            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            if (id != product.ProductId) 
                return BadRequest();

            //if (ModelState.IsValid)
            {
                var response = await _httpClient
                    .PutAsJsonAsync($"Products/{id}", product);
                
                if (response.IsSuccessStatusCode) 
                    return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _httpClient
                .GetFromJsonAsync<Product>($"Products/{id}");
            
            if (product == null) 
                return NotFound();
            
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _httpClient.DeleteAsync($"Products/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
}
