using System;
using System.Collections.Generic;

namespace DapperDb.AppDbContextModels;

public partial class Subject
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? ClassId { get; set; }

    public virtual Class? Class { get; set; }
}
