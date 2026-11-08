namespace BridgewayCodeFirst.data;
using Microsoft.EntityFrameworkCore;
using BridgewayCodeFirst.Models;

public class BridgewayDbContext : DbContext
    {
    public BridgewayDbContext(
    DbContextOptions<BridgewayDbContext> options)
    : base(options)
    {
    }
    public DbSet<Student> Students { get; set; }
        public DbSet<StudentSkill> StudentSkills { get; set; }
        public DbSet<Supervisor> Supervisors { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Partnetship> Partnetships { get; set; }


    }

