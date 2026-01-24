using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ICT2FirstMVCWebAppCS.Controllers
{
    public class MVCTestController : Controller
    {
        public ActionResult ShowData()
        {
            //int i = 20;
            string s = "ICT2";
            return View("ShowData", s);
        }

        // GET: MVCTestController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MVCTestController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MVCTestController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MVCTestController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MVCTestController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MVCTestController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MVCTestController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MVCTestController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
