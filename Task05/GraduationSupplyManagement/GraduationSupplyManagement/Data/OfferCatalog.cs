using GraduationSupplyManagement.Models;

namespace GraduationSupplyManagement.Data
{
    // The nine offers specified in the task. No database is used in Phases 1 and 2.
    public static class OfferCatalog
    {
        public static List<Offer> GetOffers()
        {
            return new List<Offer>
            {
                new Offer
                {
                    Id = 1, CategoryName = "Graduation Certificates",
                    SupplierName = "Supplier A", OfferName = "Premium Certificate Package",
                    Quantity = 35, UnitPrice = 2m
                },
                new Offer
                {
                    Id = 2, CategoryName = "Graduation Certificates",
                    SupplierName = "Supplier B", OfferName = "Standard Certificate Package",
                    Quantity = 35, UnitPrice = 1.5m
                },
                new Offer
                {
                    Id = 3, CategoryName = "Graduation Certificates",
                    SupplierName = "Supplier C", OfferName = "Luxury Certificate Package",
                    Quantity = 35, UnitPrice = 2.5m
                },
                new Offer
                {
                    Id = 4, CategoryName = "Hospitality",
                    SupplierName = "Supplier D", OfferName = "Coffee & Drinks Package",
                    Quantity = 100, UnitPrice = 2m
                },
                new Offer
                {
                    Id = 5, CategoryName = "Hospitality",
                    SupplierName = "Supplier E", OfferName = "Sandwiches & Snacks Package",
                    Quantity = 100, UnitPrice = 3m
                },
                new Offer
                {
                    Id = 6, CategoryName = "Hospitality",
                    SupplierName = "Supplier F", OfferName = "Full Hospitality Package",
                    Quantity = 100, UnitPrice = 4m
                },
                new Offer
                {
                    Id = 7, CategoryName = "Graduation Gifts",
                    SupplierName = "Supplier G", OfferName = "Customized Mugs Package",
                    Quantity = 35, UnitPrice = 2m
                },
                new Offer
                {
                    Id = 8, CategoryName = "Graduation Gifts",
                    SupplierName = "Supplier H", OfferName = "Graduation Bags Package",
                    Quantity = 35, UnitPrice = 3m
                },
                new Offer
                {
                    Id = 9, CategoryName = "Graduation Gifts",
                    SupplierName = "Supplier I", OfferName = "Premium Gift Boxes Package",
                    Quantity = 35, UnitPrice = 4m
                }
            };
        }
    }
}

