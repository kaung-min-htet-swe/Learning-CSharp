using System;
using System.Collections.Generic;

namespace Database.AppDbContextModels;

public partial class Class
{
    public int Id { get; set; }

    public string ClassCode { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}
