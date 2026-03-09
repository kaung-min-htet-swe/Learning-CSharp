using ADOWeb.Models;
using DapperDb.AppDbContextModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFWeb.controllers;

[ApiController]
[Route("api/products")]
public class ProductController(AppDbContext ctx) : ControllerBase
{
    private readonly AppDbContext _ctx = ctx;

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var prdoucts = await _ctx.Products.Where(p => p.DeleteFlag == false).ToListAsync();
        return Ok(prdoucts);
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetProductById(int id)
    {
        var product = await _ctx.Products.FirstOrDefaultAsync(p => p.ProductId == id && p.DeleteFlag == false);
        if (product is null) return NotFound("Product Not Found");
        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct(ProductRequestModel product)
    {
        await _ctx.Products.AddAsync(new Product()
        {
            ProductName = product.ProductName,
            ProductCode = product.ProductCode,
            Price = product.Price
        });
        var result = await _ctx.SaveChangesAsync();
        return Ok(result > 0 ? "Saving Successful." : "Saving Failed.");
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, ProductRequestModel product)
    {
        var p = await _ctx.Products.FirstOrDefaultAsync(p => p.ProductId == id && p.DeleteFlag == false);
        if (p is null) return NotFound("Product Not Found");

        p.ProductName = product.ProductName;
        p.ProductCode = product.ProductCode;
        p.Price = product.Price;
        var result = await _ctx.SaveChangesAsync();

        return Ok(result > 0 ? "Updating Successful." : "Updating Failed.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var p = await _ctx.Products.FirstOrDefaultAsync(p => p.ProductId == id && p.DeleteFlag == false);
        if (p is null) return NotFound("Product Not Found");
        p.DeleteFlag = true;
        var result = await _ctx.SaveChangesAsync();
        return Ok(result > 0 ? "Deleting Successful." : "Deleting Failed.");
    }
}