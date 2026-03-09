using System.Data;
using ADOWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace ADOWeb.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController(IConfiguration configuration) : ControllerBase
{
    private readonly IConfiguration _configuration = configuration;

    [HttpGet]
    public IActionResult GetProducts()
    {
        var connectionString = _configuration.GetConnectionString("DbConnection");
        using var connection = new SqlConnection(connectionString);
        connection.Open();
        const string query = "SELECT * FROM Product WHERE DeleteFlag = 0";
        using var cmd = new SqlCommand(query, connection);
        var reader = cmd.ExecuteReader();
        var products = new List<ProductModel>();

        while (reader.Read())
        {
            var product = new ProductModel
            {
                ProductID = reader.GetInt32("ProductID"),
                ProductName = reader.GetString("ProductName"),
                ProductCode = reader.GetString("ProductCode"),
                price = reader.GetDecimal("Price"),
            };
            products.Add(product);
        }

        return Ok(products);
    }

    [HttpGet("{id}")]
    public IActionResult GetProductById(int id)
    {
        var connectionString = _configuration.GetConnectionString("DbConnection");
        using var connection = new SqlConnection(connectionString);
        connection.Open();
        const string query = "SELECT * FROM Product WHERE DeleteFlag = 0 AND  ProductID = @ProductID";
        using var cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("ProductID", id);
        var reader = cmd.ExecuteReader();

        if (!reader.Read())
        {
            return NotFound("Product Not Found");
        }

        var product = new ProductModel
        {
            ProductID = reader.GetInt32("ProductID"),
            ProductName = reader.GetString("ProductName"),
            ProductCode = reader.GetString("ProductCode"),
            price = reader.GetDecimal("Price"),
        };

        return Ok(product);
    }

    [HttpPost]
    public IActionResult AddProduct(ProductRequestModel product)
    {
        var connectionString = _configuration.GetConnectionString("DbConnection");
        using var connection = new SqlConnection(connectionString);
        connection.Open();
        const string query = """
                             INSERT INTO Product (ProductName, ProductCode, Price)
                             VALUES (@ProductName, @ProductCode, @Price)
                             """;

        using var cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("ProductName", product.ProductName);
        cmd.Parameters.AddWithValue("ProductCode", product.ProductCode);
        cmd.Parameters.AddWithValue("Price", product.Price);
        var result = cmd.ExecuteNonQuery();

        return Ok(result > 0 ? "Saving Successful." : "Saving Failed.");
    }

    [HttpPatch("{id}")]
    public IActionResult UpdateProduct(int id, ProductRequestModel product)
    {
        var connectionString = _configuration.GetConnectionString("DbConnection");
        using var connection = new SqlConnection(connectionString);
        connection.Open();

        const string query = """
                             UPDATE Product SET 
                             ProductName = @ProductName,
                             ProductCode = @ProductCode,
                             Price = @Price
                             WHERE ProductID = @ProductID
                             """;
        using var cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("ProductName", product.ProductName);
        cmd.Parameters.AddWithValue("ProductCode", product.ProductCode);
        cmd.Parameters.AddWithValue("Price", product.Price);
        cmd.Parameters.AddWithValue("ProductID", id);

        var result = cmd.ExecuteNonQuery();

        return Ok(result > 0 ? "Updating Successful." : "Updating Failed.");
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(int id)
    {
        string connectionString = _configuration.GetConnectionString("DbConnection")!;
        using SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        string query = "UPDATE Product SET DeleteFlag = 1 WHERE ProductID = @ProductId";
        using var cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("ProductId", id);

        var result = cmd.ExecuteNonQuery();
        return Ok(result > 0 ? "Deleting Successful." : "Deleting Failed.");
    }
}