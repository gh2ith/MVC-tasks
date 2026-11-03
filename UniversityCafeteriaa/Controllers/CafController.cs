using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UniversityCafeteriaa.Models;

namespace UniversityCafeteriaa.Controllers
{
    public class CafController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Cafeteria");
        }

        public IActionResult Products()
        {
            return RedirectToAction("Products", "Cafeteria");
        }

        public IActionResult Suppliers()
        {
            return RedirectToAction("Suppliers", "Cafeteria");
        }

        public IActionResult SupplyStatus()
        {
            return RedirectToAction("SupplyStatus", "Cafeteria");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

