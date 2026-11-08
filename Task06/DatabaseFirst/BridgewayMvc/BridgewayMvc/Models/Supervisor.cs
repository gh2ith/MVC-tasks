using System;
using System.Collections.Generic;

namespace BridgewayMvc.Models;

public partial class Supervisor
{
    public int SupervisorId { get; set; }

    public string? FullName { get; set; }

    public int? CollegeId { get; set; }

    public string? StaffNumber { get; set; }

    public string? AcademicTitle { get; set; }

    public string? Faculty { get; set; }

    public string? Department { get; set; }

    public virtual Organization? College { get; set; }
}
