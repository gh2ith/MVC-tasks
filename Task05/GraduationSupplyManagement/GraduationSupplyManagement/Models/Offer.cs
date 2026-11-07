namespace GraduationSupplyManagement.Models
{
    public class Offer
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = "";
        public string SupplierName { get; set; } = "";
        public string OfferName { get; set; } = "";
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
