namespace BridgewayCodeFirst.Models
{
    public class Partnetship
    {
        public int PartnershipId { get; set; }
        public int CollegeId { get; set; }
        public int CompanyId { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }

        public Organization College { get; set; }
        public Organization Company { get; set; }

    }
}
