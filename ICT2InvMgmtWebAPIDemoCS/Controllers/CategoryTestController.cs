using ICT2InvMgmtWebAPIDemoCS.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ICT2InvMgmtWebAPIDemoCS.Controllers
{
    [Route("cattestapi/[controller]")]
    [ApiController]
    public class CategoryTestController : ControllerBase
    {
        private static List<Category> _categories;
        public CategoryTestController() 
        {
            if (_categories == null)
            {
                _categories = new List<Category>();
                _categories.Add(new Category
                {
                    ID = 1,
                    Name = "Electronics"
                });
                _categories.Add(new Category
                {
                    ID = 2,
                    Name = "Furniture"
                });
            }
        }
        // GET: api/<CategoryTestController>
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return _categories.ToList();
        }

        // GET api/<CategoryTestController>/5
        [HttpGet("{id}")]
        public Category Get(int id)
        {
            return _categories.SingleOrDefault(c => c.ID == id);
        }

        // POST api/<CategoryTestController>
        [HttpPost]
        public void Post( Category newCategory)
        {
            _categories.Add(newCategory);
        }

        // PUT api/<CategoryTestController>/5
        [HttpPut("{id}")]
        public void Put(int id, Category updatedCategory)
        {
            Category category = 
                _categories.SingleOrDefault(c => c.ID == id);
            if (category != null)
            {
                category.Name = updatedCategory.Name;
            }
        }

        // DELETE api/<CategoryTestController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Category category =
                _categories.SingleOrDefault(c => c.ID == id);
            if (category != null)
            {
                _categories.Remove(category);
            }
        }
    }
}
