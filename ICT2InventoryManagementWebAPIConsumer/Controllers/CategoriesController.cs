using ICT2InventoryManagementWebAPIConsumer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ICT2InventoryManagementWebAPIConsumer.Controllers
{
    public class CategoriesController : Controller
    {
        private HttpClient _httpClient;
        public CategoriesController() 
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7184/api/Categories/");
        }
        // GET: CategoriesController
        public async Task<ActionResult> Index()
        {
            var response = _httpClient.GetAsync("").Result;
            if (response.IsSuccessStatusCode)
            {
                //var content = response.Content.ReadAsStringAsync().Result;
                //var categories1 = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Category>>(content);

                //var categories = await response.Content.ReadFromJsonAsync<List<Category>>().Result;
                
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var categories = JsonSerializer.Deserialize<List<Category>>(content, options);
                return View(categories);
            }
            return View(new List<Category>());
        }

        // GET: CategoriesController/Details/5
        public async Task<ActionResult> Details(int id)
        {            
            return View((Category) await GetCategoryByID(id));
        }

        // GET: CategoriesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Category newCategory)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("", newCategory);
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriesController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View((Category)await GetCategoryByID(id));
        }

        // POST: CategoriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Category updatedCategory)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"{id}", updatedCategory);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriesController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View((Category)await GetCategoryByID(id));
        }

        // POST: CategoriesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{id}");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private async Task<Category> GetCategoryByID(int id)
        {
            var response = _httpClient.GetAsync($"{id}").Result;
            var category = new Category();
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                category = JsonSerializer.Deserialize<Category>(content, options);                
            }
            return category;
        }
    }
}
