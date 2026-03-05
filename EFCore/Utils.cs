using EFCore.DataAccess;

namespace EFCore;

public class Utils
{
    public static void PrintStudent(Student student, bool includeDepartment = false)
    {
        Console.WriteLine($"id: {student.Id}, fullname: {student.FullName}");
        if (!includeDepartment) return;

        Console.WriteLine($"{student.FullName}'s department:");
        PrintDepartment(student.Department, false);
    }

    public static void PrintDepartment(Department department, bool includeStudents = false)
    {
        Console.WriteLine($"id: {department.Id}, name: {department.DepartmentName}");
        if (!(includeStudents & department.Students.Any())) return;

        Console.WriteLine($"Students of {department.DepartmentName}");
        foreach (var student in department.Students)
        {
            PrintStudent(student, false);
        }
    }

    public static void PrintCourse(Course course, bool includeStudents = false)
    {
        Console.WriteLine($"id: {course.Id}, name: {course.CourseName}");
        if (!includeStudents) return;

        Console.WriteLine($"Students of {course.CourseName}");
    }
}