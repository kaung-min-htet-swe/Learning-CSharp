using System.Net.Sockets;
using EFCoreDemo.DepartmentModule;
using EFCoreDemo.StudentModule;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDemo;

public class CompanyContext : DbContext
{
    public CompanyContext(DbContextOptions<CompanyContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Student>()
            .HasOne((s) => s.Address)
            .WithOne((a) => a.Student)
            .HasForeignKey<Address>((a) => a.StudentId);

        modelBuilder.Entity<Department>()
            .HasMany((d) => d.Students)
            .WithOne((s) => s.Department)
            .HasForeignKey((s) => s.DepartmentId);
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Address> Addersses { get; set; }
    public DbSet<Department> Departments { get; set; }
}