using Microsoft.AspNetCore.Mvc;

namespace TupleTestMVCCoreWebAPPCS.Controllers
{
    public class TupleTestController : Controller
    {
        private static List<(int id, string name)> _items; 
        public TupleTestController()
        {
            if (_items == null)
            {
                _items = new List<(int id, string name)>
                {
                    (1, "Rajesh"),
                    (2, "Mukund"),
                    (3, "Ram")
                };
            }
            
        }
        [HttpPost]
        public IActionResult Create(int id, string name)
        {
            var newItem = (id: id, name: name);
            _items.Add(newItem);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            ViewBag.studEdit = _items.FirstOrDefault(item => item.id == id);
            ViewBag.action = "Edit";
            return View("Index", _items.ToList());
        }

        [HttpPost]
        public IActionResult Edit(int id, string name)
        {
            var item = _items.FirstOrDefault(i => i.id == id);
            //item.name = name;
            if (item != default)
            {
                _items.Remove(item);
                _items.Add((id, name));
            }
            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {
            return View(_items.ToList());
        }
    }
}
