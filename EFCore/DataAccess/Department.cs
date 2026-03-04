using System;
using System.Collections.Generic;

namespace EFCore.DataAccess;

public partial class Department:Base
{
    public string DepartmentName { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
