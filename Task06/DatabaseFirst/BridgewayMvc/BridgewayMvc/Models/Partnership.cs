using System;
using System.Collections.Generic;

namespace BridgewayMvc.Models;

public partial class Partnership
{
    public int PartnershipId { get; set; }

    public int? CollegeId { get; set; }

    public int? CompanyId { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Organization? College { get; set; }

    public virtual Organization? Company { get; set; }
}
