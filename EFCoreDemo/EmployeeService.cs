using Microsoft.EntityFrameworkCore;

namespace EFCoreDemo;

public class EmployeeService
{
    public async Task<Employee> Create(CompanyContext ctx)
    {
        var employee = new Employee()
        {
            Name = "New Employee",
            Department = "Department 1",
        };

        ctx.Employees.Add(employee);

        await ctx.SaveChangesAsync();

        return employee;
    }

    public async Task<List<Employee>> Read(CompanyContext ctx)
    {
        var team = await ctx.Employees
            .Where(e => e.Department == "Department 1")
            .ToListAsync();

        return team;
    }

    public async Task<Employee?> Update(CompanyContext ctx, int id)
    {
        var e = await ctx.Employees.FindAsync(id);
        if (e is not null)
        {
            e.Department = "Updated Department";

            await ctx.SaveChangesAsync();
        }

        return e;
    }

    public async Task<Employee> Delete(CompanyContext ctx, int id)
    {
        var employee = await ctx.Employees.FindAsync(id);

        if (employee != null)
        {
            ctx.Employees.Remove(employee);
            await ctx.SaveChangesAsync();
        }

        return employee;
    }
}