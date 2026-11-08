namespace BridgewayCodeFirst.Models
{
    public class Organization
    {
        public int OrganizationId { get; set; }
        public string Kind { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Status { get; set; }

        public ICollection<Student> Students { get; set; }
        public ICollection<Supervisor> Supervisors { get; set; }
        public ICollection<Partnetship> CollegePartnerships { get; set; }
        public ICollection<Partnetship> CompanyPartnerships { get; set; }

    }
}
