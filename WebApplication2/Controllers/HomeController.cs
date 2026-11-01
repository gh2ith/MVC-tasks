using Microsoft.AspNetCore.Mvc;

namespace UniversityCafeteria.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Error()
        {
            return View();
        }
    }
}
