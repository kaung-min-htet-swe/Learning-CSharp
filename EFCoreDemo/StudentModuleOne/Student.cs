using EFCoreDemo.DepartmentModule;
using EFCoreDemo.Shared;

namespace EFCoreDemo.StudentModule;

public class Student
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }

    public Address Address { get; set; } = null!;

    public int? DepartmentId { get; set; }
    public Department? Department { get; set; } = null!;
}