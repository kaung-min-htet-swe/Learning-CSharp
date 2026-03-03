using EFCoreDemo.StudentModule;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDemo;

public class CompanyContext : DbContext
{
    public CompanyContext(DbContextOptions<CompanyContext> options) : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Student> Students { get; set; }
}