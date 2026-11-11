using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Task08.Models;

public class ApplicationUser : IdentityUser
{
    [Required]
    public string FullName { get; set; } = "";
}
