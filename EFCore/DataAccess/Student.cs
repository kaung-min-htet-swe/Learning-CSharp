using System;
using System.Collections.Generic;

namespace EFCore.DataAccess;

public partial class Student : Base
{
    public string FullName { get; set; } = null!;

    public int DepartmentId { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}