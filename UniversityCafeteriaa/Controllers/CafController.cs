using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UniversityCafeteriaa.Models;

namespace UniversityCafeteriaa.Controllers
{
    public class CafController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Products()
        {
            return View();
        }

        public IActionResult Suppliers()
        {
            return View();
        }

        public IActionResult SupplyStatus()
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
