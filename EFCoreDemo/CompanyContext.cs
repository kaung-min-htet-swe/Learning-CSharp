using System.Net.Sockets;
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
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Address> Addersses { get; set; }
}