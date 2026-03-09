namespace AdoWebAPI.Models;

public class ProductModel
{
    public int ProductID { get; set; }
    public string ProductName { get; set; }
    public string ProductCode { get; set; }
    public decimal Price { get; set; }
    public bool DeleteFlag { get; set; }
}