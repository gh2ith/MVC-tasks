using Microsoft.AspNetCore.Mvc;

namespace UniversityCafeteriaa.Controllers
{
    public class SupplyController : Controller
    {
        public IActionResult Index()
        {
            string[] categories = { "Drinks", "Food", "Snacks", "Hot Drinks", "Cold Drinks" };
            ViewBag.Categories = categories;
            return View();
        }

        public IActionResult Products()
        {
            ViewData["Title"] = "Cafeteria Products";
            ViewData["ManagerName"] = "Ahmad Ali";
            ViewData["NumberOfProducts"] = 5;
            ViewData["Products"] = new string[] { "Water", "Orange Juice", "Coffee", "Sandwich", "Chocolate" };
            return View();
        }

        public IActionResult Suppliers()
        {
            ViewBag.Title = "Our Suppliers";
            ViewBag.NumberOfSuppliers = 3;
            ViewBag.Suppliers = new string[]
            {
                "Fresh Food Company", "Happy Drinks Company", "Daily Supplies Company"
            };
            return View();
        }

        [HttpGet]
        public IActionResult CreateRequest()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SubmitRequest()
        {
            // Read the values using the input names in the form.
            string employeeName = Request.Form["EmployeeName"].ToString().Trim();
            string productName = Request.Form["ProductName"].ToString();
            string quantityText = Request.Form["Quantity"].ToString();
            string requiredDate = Request.Form["RequiredDate"].ToString();

            if (string.IsNullOrWhiteSpace(employeeName))
            {
                ViewBag.Error = "Please enter the employee name.";
                return View();
            }

            if (!int.TryParse(quantityText, out int quantity) || quantity <= 0)
            {
                ViewBag.Error = "Please enter a whole quantity greater than zero.";
                return View();
            }

            TempData["Message"] = $"Request submitted successfully for {employeeName}: {quantity} {productName}, required on {requiredDate}.";
            return RedirectToAction("About");
        }

        public IActionResult About()
        {
            return View();
        }

        // MVC reads quantity from the URL, such as /Supply/CheckQuantity?quantity=25.
        [HttpGet]
        public IActionResult CheckQuantity(int quantity)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "Please enter a valid whole number.";
            }
            else if (quantity < 20)
            {
                ViewBag.Message = "Small Order";
            }
            else if (quantity <= 50)
            {
                ViewBag.Message = "Medium Order";
            }
            else
            {
                ViewBag.Message = "Large Order";
            }

            ViewBag.Quantity = quantity;
            return View();
        }
    }
}

