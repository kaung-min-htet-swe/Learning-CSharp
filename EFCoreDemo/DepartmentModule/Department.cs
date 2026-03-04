using EFCoreDemo.Shared;
using EFCoreDemo.StudentModuleOne;

namespace EFCoreDemo.DepartmentModule;

public class Department:Entity
{
    public string Name { get; set; }

    public ICollection<Student> Students { get; set; } = new List<Student>();
}