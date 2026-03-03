namespace EFCoreDemo.Shared;

using EFCoreDemo.StudentModule;

public class Ulits
{
    public static void PrintEmployee(Employee employee)
    {
        Console.WriteLine($"id: {employee.Id}, name; {employee.Name}, department: {employee.Department}");
    }

    public static void PrintStudent(Student student)
    {
        Console.WriteLine($"id: {student.Id}, name; {student.Name}, age: {student.Age}");
        PrintAddress(student.Address);
    }

    public static void PrintAddress(Address address)
    {
        Console.WriteLine(
            $"id: {address.Id}, addreLine: {address.AddreLine},township: {address.Township}, state: {address.State}");
    }
}