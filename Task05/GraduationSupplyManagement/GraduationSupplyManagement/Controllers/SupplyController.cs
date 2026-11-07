using System.Text.Json;
using GraduationSupplyManagement.Data;
using GraduationSupplyManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace GraduationSupplyManagement.Controllers
{
    public class SupplyController : Controller
    {
        private readonly int _phase;

        public SupplyController(IConfiguration configuration)
        {
            _phase = configuration.GetValue<int>("TaskPhase");
        }

        public IActionResult Index()
        {
            return RedirectToAction("Create");
        }

        public IActionResult Create()
        {
            var offers = GetOffers();
            var selectedOffers = ReadSelections();
            ViewBag.SelectedIds = selectedOffers.Select(offer => offer.Id).ToList();
            ViewBag.SelectedCount = selectedOffers.Count;
            ViewBag.LastSupplier = Request.Cookies["LastSupplier"];
            return View(offers);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Select(int offerId)
        {
            // Prices and categories come from our data, not from hidden form inputs.
            var offer = GetOffers().FirstOrDefault(item => item.Id == offerId);
            if (offer == null)
            {
                return BadRequest("That offer does not exist.");
            }

            if (_phase == 1)
            {
                string key = GetSessionKey(offer.CategoryName);
                HttpContext.Session.SetString(key, JsonSerializer.Serialize(offer));
            }
            else
            {
                var selectedOffers = ReadSelections();
                selectedOffers.RemoveAll(item => item.CategoryName == offer.CategoryName);
                selectedOffers.Add(offer);
                HttpContext.Session.SetString("SelectedOffers", JsonSerializer.Serialize(selectedOffers));
            }

            Response.Cookies.Append("LastSupplier", offer.SupplierName, new CookieOptions
            {
                HttpOnly = true,
                SameSite = SameSiteMode.Lax,
                Secure = Request.IsHttps,
                Expires = DateTimeOffset.UtcNow.AddDays(7)
            });

            TempData["Message"] = offer.OfferName + " selected.";
            return RedirectToAction("Create");
        }

        public IActionResult Review()
        {
            var savedOffers = ReadSelections();
            var selectedOffers = GetOffers()
                .Where(offer => savedOffers.Any(saved => saved.Id == offer.Id))
                .ToList();

            if (selectedOffers.Count != 3 ||
                !selectedOffers.Any(offer => offer.CategoryName == "Graduation Certificates") ||
                !selectedOffers.Any(offer => offer.CategoryName == "Hospitality") ||
                !selectedOffers.Any(offer => offer.CategoryName == "Graduation Gifts"))
            {
                TempData["Error"] = "Select one offer from each category before reviewing your request.";
                return RedirectToAction("Create");
            }

            decimal total = 0;
            foreach (var offer in selectedOffers)
            {
                offer.TotalPrice = offer.Quantity * offer.UnitPrice;
                total += offer.TotalPrice;
            }

            decimal discountPercentage = 0;
            if (total > 500)
            {
                discountPercentage = 15;
            }
            else if (total > 300)
            {
                discountPercentage = 10;
            }

            decimal discountAmount = total * discountPercentage / 100;
            ViewBag.Total = total;
            ViewBag.DiscountPercentage = discountPercentage;
            ViewBag.DiscountAmount = discountAmount;
            ViewBag.FinalTotal = total - discountAmount;
            return View(selectedOffers);
        }

        public IActionResult About()
        {
            return View();
        }

        private List<Offer> GetOffers()
        {
            return OfferCatalog.GetOffers();
        }

        private List<Offer> ReadSelections()
        {
            if (_phase == 1)
            {
                var selectedOffers = new List<Offer>();
                string[] keys = { "CertificatesOffer", "HospitalityOffer", "GiftsOffer" };
                foreach (string key in keys)
                {
                    string? json = HttpContext.Session.GetString(key);
                    if (json != null)
                    {
                        var offer = JsonSerializer.Deserialize<Offer>(json);
                        if (offer != null)
                        {
                            selectedOffers.Add(offer);
                        }
                    }
                }
                return selectedOffers;
            }

            string? savedList = HttpContext.Session.GetString("SelectedOffers");
            if (savedList == null)
            {
                return new List<Offer>();
            }
            return JsonSerializer.Deserialize<List<Offer>>(savedList) ?? new List<Offer>();
        }

        private string GetSessionKey(string category)
        {
            switch (category)
            {
                case "Graduation Certificates":
                    return "CertificatesOffer";
                case "Hospitality":
                    return "HospitalityOffer";
                case "Graduation Gifts":
                    return "GiftsOffer";
                default:
                    throw new ArgumentException("Unknown category.");
            }
        }
    }
}


