using IdentityManagementDemoAppCS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

//7e192629-8f4c-4cf5-863c-84335b100bba

//aspnet-IdentityManagementDemoAppCS-f6a33cef-48c3-42bf-8e69-425abba9b838

namespace IdentityManagementDemoAppCS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
