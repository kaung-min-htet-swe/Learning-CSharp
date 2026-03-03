namespace EFCoreDemo.Migrations;

public class Ulits
{
    public static void PrintEmployee(Employee employee)
    {
        Console.WriteLine($"id: {employee.Id}, name; {employee.Name}, department: {employee.Department}");
    }
}