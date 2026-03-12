using Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NorthWindMVC.Dtos;

namespace NorthWindMVC.Controllers;

public class DashboardController(AppDbContext db):Controller
{
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpGet]
    public async Task<IActionResult> GetBestSellingProducts()
    {
        var sqlQuery = @"
                SELECT TOP 5
                    P.ProductName,
                    SUM(OD.Quantity) AS TotalQuantity
                FROM
                    [Order Details] OD
                JOIN
                    Products P ON OD.ProductID = P.ProductID
                GROUP BY
                    P.ProductName
                ORDER BY
                    TotalQuantity DESC";
            
        var topProducts = await db.Database
            .SqlQueryRaw<BestSellingProductDto>(sqlQuery)
            .ToListAsync();

        return Json(topProducts);
    }
}