using System;
using System.Collections.Generic;

namespace BridgewayMvc.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string? FullName { get; set; }

    public int? CollegeId { get; set; }

    public string? StudentNumber { get; set; }

    public string? Faculty { get; set; }

    public string? Department { get; set; }

    public int? StudyYear { get; set; }

    public decimal? Gpa { get; set; }

    public virtual Organization? College { get; set; }

    public virtual ICollection<StudentSkill> StudentSkills { get; set; } = new List<StudentSkill>();
}
