using Microsoft.EntityFrameworkCore;
using UniversityCafeteria.Models;

namespace UniversityCafeteria.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().Property(x => x.Price).HasPrecision(18, 2);
        modelBuilder.Entity<Employee>().Property(x => x.Salary).HasPrecision(18, 2);
        modelBuilder.Entity<Order>().Property(x => x.TotalPrice).HasPrecision(18, 2);
    }
}
