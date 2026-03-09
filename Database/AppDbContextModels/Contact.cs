using System;
using System.Collections.Generic;

namespace Database.AppDbContextModels;

public partial class Contact
{
    public int Id { get; set; }

    public string Phone { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int? StudentId { get; set; }

    public virtual Student? Student { get; set; }
}
