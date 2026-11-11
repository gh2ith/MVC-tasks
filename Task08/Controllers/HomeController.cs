using Microsoft.AspNetCore.Mvc;

namespace Task08.Controllers;

public class HomeController : Controller
{
    public IActionResult Index() => View();
    public IActionResult Error() => View();
}
