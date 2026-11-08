using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BridgewayMvc.Models;

public partial class BridgewayDbContext : DbContext
{
    public BridgewayDbContext(DbContextOptions<BridgewayDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Organization> Organizations { get; set; }

    public virtual DbSet<Partnership> Partnerships { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentSkill> StudentSkills { get; set; }

    public virtual DbSet<Supervisor> Supervisors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Organization>(entity =>
        {
            entity.HasKey(e => e.OrganizationId).HasName("PK__Organiza__CADB0B1209B66A9E");

            entity.ToTable("Organization");

            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.Kind).HasMaxLength(20);
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.Phone).HasMaxLength(30);
            entity.Property(e => e.Status).HasMaxLength(20);
        });

        modelBuilder.Entity<Partnership>(entity =>
        {
            entity.HasKey(e => e.PartnershipId).HasName("PK__Partners__AD185E797DA631C5");

            entity.ToTable("Partnership");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(20);

            entity.HasOne(d => d.College).WithMany(p => p.PartnershipColleges)
                .HasForeignKey(d => d.CollegeId)
                .HasConstraintName("FK__Partnersh__Colle__5535A963");

            entity.HasOne(d => d.Company).WithMany(p => p.PartnershipCompanies)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK__Partnersh__Compa__5629CD9C");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Student__32C52B99ED622C5B");

            entity.ToTable("Student");

            entity.Property(e => e.Department).HasMaxLength(100);
            entity.Property(e => e.Faculty).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Gpa).HasColumnType("decimal(3, 2)");
            entity.Property(e => e.StudentNumber).HasMaxLength(40);

            entity.HasOne(d => d.College).WithMany(p => p.Students)
                .HasForeignKey(d => d.CollegeId)
                .HasConstraintName("FK__Student__College__4CA06362");
        });

        modelBuilder.Entity<StudentSkill>(entity =>
        {
            entity.HasKey(e => new { e.StudentId, e.Skill }).HasName("PK__StudentS__4BCAA4C596B3BB6E");

            entity.ToTable("StudentSkill");

            entity.Property(e => e.Skill).HasMaxLength(40);

            entity.HasOne(d => d.Student).WithMany(p => p.StudentSkills)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StudentSk__Stude__4F7CD00D");
        });

        modelBuilder.Entity<Supervisor>(entity =>
        {
            entity.HasKey(e => e.SupervisorId).HasName("PK__Supervis__6FAABDCFDC21908A");

            entity.ToTable("Supervisor");

            entity.Property(e => e.AcademicTitle).HasMaxLength(30);
            entity.Property(e => e.Department).HasMaxLength(100);
            entity.Property(e => e.Faculty).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.StaffNumber).HasMaxLength(40);

            entity.HasOne(d => d.College).WithMany(p => p.Supervisors)
                .HasForeignKey(d => d.CollegeId)
                .HasConstraintName("FK__Superviso__Colle__52593CB8");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
