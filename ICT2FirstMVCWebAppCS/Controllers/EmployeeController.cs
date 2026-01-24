using ICT2FirstMVCWebAppCS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ICT2FirstMVCWebAppCS.Controllers
{
    public class EmployeeController : Controller
    {
        private static List<Employee> employees = new List<Employee>();

        public EmployeeController()
        {
            if (employees.Count == 0)
            {
                employees.Add(
                    new Employee
                    {
                        EmployeeID = 1,
                        Name = "ABC",
                        Age = 30,
                        Salary = 30000
                    });
                employees.Add(
                    new Employee
                    {
                        EmployeeID = 2,
                        Name = "PQR",
                        Age = 28,
                        Salary = 25000
                    });
                employees.Add(
                    new Employee
                    {
                        EmployeeID = 3,
                        Name = "XYZ",
                        Age = 32,
                        Salary = 20000
                    });
            }
        }

        // GET: EmployeeController/Create
        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SearchResult(EmpSearch empToSearch)
        {
            var searchList = employees.ToList();



            return View(searchList.ToList());
        }

        // GET: EmployeeController
        public ActionResult ShowGT30()
        {
            return View(employees.Where(e => e.Age > 30).ToList());
        }

        // GET: EmployeeController
        public ActionResult Index(int ?age, string ?str)
        {
            if (age != null)
            {
                if (str != null)
                {
                    var empList = employees.Where(e => e.Age > age)
                        .Where(e => e.Name.Contains(str));
                        
                    return View(empList.ToList());
                }
                return View(employees.Where(e => e.Age > age).ToList());
            }
            return View(employees.ToList());
        }

        
        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            return View(employees.SingleOrDefault(e=>e.EmployeeID == id));
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee newEmployee)
        {
            try
            {
                employees.Add(newEmployee);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(employees.SingleOrDefault(e => e.EmployeeID == id));
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employee updatedEmployee)
        {
            try
            {
                Employee employeeToUpdate = employees.SingleOrDefault(e => e.EmployeeID == id);
                employeeToUpdate.Name = updatedEmployee.Name;
                employeeToUpdate.Age = updatedEmployee.Age; 
                employeeToUpdate.Salary = updatedEmployee.Salary;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(employees.SingleOrDefault(e => e.EmployeeID == id));
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                employees.Remove(employees.SingleOrDefault(e => e.EmployeeID == id));    
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
