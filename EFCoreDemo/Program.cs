using EFCoreDemo;
using EFCoreDemo.Migrations;
using EFCoreDemo.Shared;
using EFCoreDemo.StudentModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

Console.WriteLine("EF Core Demo");

var contextFactory = new CompanyContextFactory();
var db = contextFactory.CreateDbContext();
// var addressService = new AddressService(db);
// var address = await AddressTestDemo.UpdateAddressTest(addressService);
// Ulits.PrintAddress(address);

await StudentModule.Run(db);

// var employee = new EmployeeService();
// var employees = await employee.Read(db);

// var optionsBuilder = new DbContextOptionsBuilder<CompanyContext>();
// optionsBuilder.UseSqlServer(
//     "Server=localhost;User ID=sa;Password=DataC0Ntr0ll3r;Encrypt=True;Database=efcore;TrustServerCertificate=True;"
// );
//
// var companyContext = new CompanyContext(optionsBuilder.Options);
// var employeeService = new EmployeeService();

// var employee = await employeeService.Create(companyContext);
// Console.WriteLine($"employee.Name: {employee.Name}, employee.Department: {employee.Department}");

// var employess = await employeeService.Read(companyContext);
// foreach (var e in employess)
// {
//     Ulits.PrintEmployee(e);
// }
//
// var updatedEmployee = await employeeService.Update(companyContext, 1);
// if (updatedEmployee is not null)
// {
//     Ulits.PrintEmployee(updatedEmployee);
// }
//
// var deletedEmployee = await employeeService.Delete(companyContext, 1);
// if (deletedEmployee is not null)
// {
//     Ulits.PrintEmployee(deletedEmployee);
// }


public class CompanyContextFactory : IDesignTimeDbContextFactory<CompanyContext>
{
    public CompanyContext CreateDbContext(params string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<CompanyContext>();
        optionsBuilder.UseSqlServer(
            "Server=localhost;User ID=sa;Password=DataC0Ntr0ll3r;Encrypt=True;Database=efcore;TrustServerCertificate=True;");
        return new CompanyContext(optionsBuilder.Options);
    }
}
