using System.ComponentModel.DataAnnotations;

namespace UniversityCafeteria.Models;

public class Supplier
{
    public int Id { get; set; }

    [Required, StringLength(100)]
    public string Name { get; set; } = "";

    [Required, Phone, StringLength(30)]
    public string Phone { get; set; } = "";

    [Required, EmailAddress, StringLength(200)]
    public string Email { get; set; } = "";

    public ICollection<Product> Products { get; set; } = new List<Product>();
}
