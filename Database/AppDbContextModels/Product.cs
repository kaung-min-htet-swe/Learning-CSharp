using System;
using System.Collections.Generic;

namespace Database.AppDbContextModels;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public string ProductCode { get; set; } = null!;

    public decimal Price { get; set; }

    public bool DeleteFlag { get; set; }
}
