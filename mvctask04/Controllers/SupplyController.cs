using Microsoft.AspNetCore.Mvc;

namespace mvctask04.Controllers
{
    public class SupplyController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Categories = new string[] { "Drinks", "Food", "Snacks", "Hot Drinks", "Cold Drinks" };
            return View();
        }

        public IActionResult Products()
        {
            ViewData["Title"] = "Cafeteria Products";
            ViewData["ManagerName"] = "Ahmad Ali";
            ViewData["ProductsCount"] = 5;
            ViewData["ProductList"] = new string[] { "Water", "Orange Juice", "Coffee", "Sandwich", "Chocolate" };

            return View();
        }

        public IActionResult Suppliers()
        {
            ViewBag.Title = "Our Suppliers";
            ViewBag.SuppliersCount = 3;
            ViewBag.SuppliersList = new string[] { "Fresh Food Company", "Happy Drinks Company", "Daily Supplies Company" };

            return View();
        }

        [HttpGet]
        public IActionResult CreateRequest()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitRequest()
        {
            string empName = Request.Form["EmployeeName"].ToString().Trim();
            string productName = Request.Form["ProductName"].ToString();
            string quantityStr = Request.Form["Quantity"].ToString();
            string requiredDate = Request.Form["RequiredDate"].ToString();

            if (string.IsNullOrWhiteSpace(empName))
            {
                ViewBag.ErrorMessage = "Please enter the employee name.";
                return View("CreateRequest");
            }

            if (!int.TryParse(quantityStr, out int quantity) || quantity <= 0)
            {
                ViewBag.ErrorMessage = "Please enter a quantity greater than zero.";
                return View("CreateRequest");
            }

            string[] products = { "Water", "Orange Juice", "Coffee", "Sandwich", "Chocolate" };
            if (!products.Contains(productName))
            {
                ViewBag.ErrorMessage = "Please choose a product from the list.";
                return View("CreateRequest");
            }

            if (!DateOnly.TryParseExact(requiredDate, "yyyy-MM-dd",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out DateOnly deliveryDate))
            {
                ViewBag.ErrorMessage = "Please choose a valid required date.";
                return View("CreateRequest");
            }

            TempData["Message"] = $"Request submitted by {empName}: {quantity} {productName}, required on {deliveryDate:yyyy-MM-dd}.";

            if (quantity < 20)
            {
                TempData["QuantityMessage"] = "Order Size Classification: Small Order";
            }
            else if (quantity >= 20 && quantity <= 50)
            {
                TempData["QuantityMessage"] = "Order Size Classification: Medium Order";
            }
            else
            {
                TempData["QuantityMessage"] = "Order Size Classification: Large Order";
            }

            return RedirectToAction("About");
        }

        [HttpGet]
        public IActionResult CheckQuantity(int quantity)
        {
            if (!ModelState.IsValid || quantity < 0)
                ViewBag.QuantityMessage = "Please enter a valid quantity.";
            else if (quantity < 20)
                ViewBag.QuantityMessage = "Small Order";
            else if (quantity <= 50)
                ViewBag.QuantityMessage = "Medium Order";
            else
                ViewBag.QuantityMessage = "Large Order";

            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}