namespace BridgewayCodeFirst.Models
{
    public class Supervisor
    {
        public int SupervisorId { get; set; }
        public string FullName { get; set; }
        public int CollegeId { get; set; }
        public string StaffNumber { get; set; }
        public string AcademicTitle { get; set; }
        public string Faculty { get; set; }
        public string Department { get; set; }

        public Organization College { get; set; }


    }
}
