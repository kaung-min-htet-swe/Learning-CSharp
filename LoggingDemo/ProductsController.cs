using Microsoft.AspNetCore.Mvc;
using Serilog;
using ILogger = Serilog.ILogger;

namespace LoggingDemo;

public record CreateRequestDto(String Name);

public record CreateResponseDto(Guid Id, String Name);

[ApiController]
[Route("api/products")]
public class ProductsController(ILogger<ProductsController> logger) : ControllerBase
{
    [HttpGet]
    public IActionResult GetProducts()
    {
        logger.LogInformation("GetProducts methods called");
        var products = new List<string> { "Product1", "Product2", "Product3" };

        Log.Information("Retrieved {ProductCount} products", products.Count);

        return Ok(products);
    }

    [HttpPost]
    public IActionResult CreateProduct([FromBody] CreateRequestDto product)
    {
        logger.LogInformation("Creating product: {ProductName}", product.Name);

        if (string.IsNullOrEmpty(product.Name))
        {
            Log.Warning("Empty product name provided");
            return BadRequest("Product name cannot be empty");
        }

        var newProduct = new CreateResponseDto(Guid.NewGuid(), product.Name);
        logger.LogInformation("Product created successfully: {ProductName}", newProduct.Name);

        return Ok(newProduct);
    }

    [HttpGet("{id}")]
    public IActionResult GetProduct(int id)
    {
        try
        {
            Log.Information("Getting product with ID: {ProductId}", id);

            if (id <= 0)
            {
                logger.LogWarning("Invalid product ID: {ProductId}", id);
                return BadRequest("Invalid product ID");
            }

            var product = $"Product{id}";
            logger.LogInformation("Product found: {ProductName}", product);

            return Ok(product);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Error getting product with ID: {ProductId}", id);
            return StatusCode(500, "Internal server error");
        }
    }
}