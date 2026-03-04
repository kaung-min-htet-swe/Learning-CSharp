using EFCore.DataAccess;

namespace EFCore;

public class Utils
{
    public static void PrintStudent(Student student, bool includeDepartment = false)
    {
        Console.WriteLine($"id: {student.Id}, fullname: {student.FullName}");
        if (includeDepartment)
            PrintDepartment(student.Department, false);
    }

    public static void PrintDepartment(Department department, bool includeStudents = false)
    {
        Console.WriteLine($"id: {department.Id}, name: {department.DepartmentName}");
        if (includeStudents & department.Students.Any())
        {
            Console.WriteLine("Students:");
            foreach (var student in department.Students)
            {
                PrintStudent(student, false); 
            }
        }
    }
}