using System.Data;
using ADOWeb.Models;
using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace DapperWeb.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController(IConfiguration configuration) : ControllerBase
{
    private readonly IConfiguration _configuration = configuration;

    [HttpGet]
    public IActionResult GetProducts()
    {
        using IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DbConnection"));
        var products = db.Query<ProductModel>("SELECT * FROM Product WHERE DeleteFlag = 0");
        return Ok(products);
    }

    [HttpGet("{id}")]
    public IActionResult GetProductById(int id)
    {
        using IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DbConnection"));
        var product = db.Query<ProductModel>("SELECT * FROM Product WHERE DeleteFlag = 0 And ProductID = @ProductID",
            new
            {
                ProductID = id,
            });
        if (product is null) return NotFound("Product Not Found");

        return Ok(product);
    }

    [HttpPost]
    public IActionResult AddProduct(ProductRequestModel product)
    {
        using IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DbConnection"));
        var query = """
                    INSERT INTO Product (ProductName, ProductCode, Price)
                    VALUES (@ProductName, @ProductCode, @Price)
                    """;
        var result = db.Execute(query, product);
        return Ok(result > 0 ? "Saving Successful." : "Saving Failed.");
    }

    [HttpPatch("{id}")]
    public IActionResult Update(int id, ProductRequestModel product)
    {
        using IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DbConnection"));
        const string query = """
                             UPDATE Product SET 
                             ProductName = @ProductName,
                             ProductCode = @ProductCode,
                             Price = @Price
                             WHERE ProductID = @ProductID
                             """;
        var result = db.Execute(query, new
        {
            product.ProductName,
            product.ProductCode,
            product.Price,
            ProductID = id,
        });
        return Ok(result > 0 ? "Updating Successful." : "Updating Failed.");
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var query = "UPDATE Product SET DeleteFlag = 1 WHERE ProductID = @ProductID";
        using IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DbConnection"));
        var result = db.Execute(query, new { ProductID = id });
        return Ok(result > 0 ? "Deleting Successful." : "Deleting Failed.");
    }
}