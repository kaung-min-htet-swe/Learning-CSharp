namespace ADOWeb.Models;

public class ProductModel
{
    public int ProductID { get; set; }
    public string ProductName { get; set; }
    public string ProductCode { get; set; }
    public decimal price;
    public bool DeleteFlag { get; set; }
}