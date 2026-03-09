using System;
using System.Collections.Generic;

namespace DapperDb.AppDbContextModels;

public partial class Major
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? MajorCode { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
