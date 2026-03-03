using Microsoft.EntityFrameworkCore;

namespace EFCoreDemo;

public class CompanyContext : DbContext
{
    public CompanyContext(DbContextOptions<CompanyContext> options) : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }
}