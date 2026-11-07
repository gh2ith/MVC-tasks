using CafeteriaCodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace CafeteriaCodeFirst.data
{
    public class CafeteriaEmployeesContext : DbContext
    {
        public CafeteriaEmployeesContext(DbContextOptions<CafeteriaEmployeesContext> options) : base(options)
        {
        }
    
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; } = null!;
        public DbSet<products> Products { get; set; } = null!;
        public DbSet<category> Categories { get; set; } = null!;
        public DbSet<Supplier> Suppliers { get; set; } = null!;
        public DbSet<PurchaseOrderItem> PurchaseOrderItems { get; set; } = null!;
    }
}
