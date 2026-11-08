using System;
using System.Collections.Generic;

namespace BridgewayMvc.Models;

public partial class StudentSkill
{
    public int StudentId { get; set; }

    public string Skill { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
