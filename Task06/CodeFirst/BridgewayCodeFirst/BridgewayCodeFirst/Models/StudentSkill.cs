namespace BridgewayCodeFirst.Models
{
    public class StudentSkill
    {
        public int StudentId { get; set; }
        public string Skill { get; set; }

        public Student Student { get; set; }

    }
}
