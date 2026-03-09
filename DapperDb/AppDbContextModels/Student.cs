using System;
using System.Collections.Generic;

namespace DapperDb.AppDbContextModels;

public partial class Student
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Age { get; set; }

    public int? ClassId { get; set; }

    public int? MajorId { get; set; }

    public virtual Class? Class { get; set; }

    public virtual ICollection<Contact> Contacts { get; set; } = new List<Contact>();

    public virtual Major? Major { get; set; }
}
