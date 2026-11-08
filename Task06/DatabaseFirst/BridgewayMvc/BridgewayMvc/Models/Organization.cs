using System;
using System.Collections.Generic;

namespace BridgewayMvc.Models;

public partial class Organization
{
    public int OrganizationId { get; set; }

    public string? Kind { get; set; }

    public string? Name { get; set; }

    public string? City { get; set; }

    public string? Phone { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Partnership> PartnershipColleges { get; set; } = new List<Partnership>();

    public virtual ICollection<Partnership> PartnershipCompanies { get; set; } = new List<Partnership>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<Supervisor> Supervisors { get; set; } = new List<Supervisor>();
}
