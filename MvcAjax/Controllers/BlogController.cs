using DotNetDatabase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MvcAjax.Controllers;

public class BlogController(AppDbContext ctx) : Controller
{
    private readonly AppDbContext _db = ctx;

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> List()
    {
        var blogs = await _db.TblBlogs
            .AsNoTracking()
            .OrderByDescending(b => b.BlogId)
            .ToListAsync();

        return Json(blogs);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Save(TblBlog blog)
    {
        await _db.TblBlogs.AddAsync(blog);
        var res = await _db.SaveChangesAsync();
        var response = new
        {
            IsSuccess = res > 0,
            Message = res > 0 ? "Saving Successful." : "Saving Failed."
        };
        return Json(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetById(int id)
    {
        var blog = await _db.TblBlogs.FirstOrDefaultAsync(blog => blog.BlogId == id);
        if (blog == null) return Json(new { IsSuccess = false, Message = "Blog not found." });

        return Json(blog);
    }

    public IActionResult Edit(int id)
    {
        ViewBag.BlogId = id;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Update(int id, TblBlog blog)
    {
        var b = await _db.TblBlogs.FirstOrDefaultAsync(b => b.BlogId == id);
        if (b is null) return Json(new { IsSuccess = false, Message = "Blog not found." });

        b.BlogTitle = blog.BlogTitle;
        b.BlogAuthor = blog.BlogAuthor;
        b.BlogContent = blog.BlogContent;

        var res = await _db.SaveChangesAsync();
        var response = new
        {
            IsSuccess = res > 0,
            Message = res > 0 ? "Updating Successful." : "Updating Failed."
        };
        return Json(response);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var b = await _db.TblBlogs.FirstOrDefaultAsync(b => b.BlogId == id);
        if (b is null) return Json(new { IsSuccess = false, Message = "Blog not found." });

        _db.TblBlogs.Remove(b);
        var result = await _db.SaveChangesAsync();

        var response = new
        {
            IsSuccess = result > 0,
            Message = result > 0 ? "Deleting Successful." : "Deleting Failed."
        };
        return Json(response);
    }
}