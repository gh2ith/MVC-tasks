namespace BridgewayCodeFirst.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FullName { get; set; }
        public int CollegeId { get; set; }
        public string StudentNumber { get; set; }
        public string Faculty { get; set; }
        public string Department { get; set; }
        public int StudyYear { get; set; }
        public decimal Gpa { get; set; }

        public Organization College { get; set; }
        public ICollection<StudentSkill> StudentSkills { get; set; }

    }
}
