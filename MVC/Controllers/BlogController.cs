using DotNetDatabase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MVC.Controllers;

public class BlogController(AppDbContext ctx) : Controller
{
    private readonly AppDbContext _db = ctx;

    public async Task<IActionResult> Index()
    {
        var blogs = await _db.TblBlogs
            .AsNoTracking()
            .OrderByDescending(blog => blog.BlogId)
            .ToListAsync<TblBlog>();

        return View(blogs);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Save(TblBlog blog)
    {
        await _db.TblBlogs.AddAsync(blog);
        await _db.SaveChangesAsync();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var blog = await _db.TblBlogs.FirstOrDefaultAsync(blog => blog.BlogId == id);
        if (blog == null) return RedirectToAction("Index");

        return View(blog);
    }

    [HttpPost]
    public async Task<ActionResult> Update(int id, TblBlog blog)
    {
        var item = await _db.TblBlogs.FirstOrDefaultAsync(x => x.BlogId == id);
        if (item is null)
        {
            return RedirectToAction("Index");
        }

        item.BlogTitle = blog.BlogTitle;
        item.BlogAuthor = blog.BlogAuthor;
        item.BlogContent = blog.BlogContent;

        await _db.SaveChangesAsync();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<ActionResult> Delete(int id)
    {
        var item = await _db.TblBlogs.FirstOrDefaultAsync(x => x.BlogId == id);
        if (item is null)
        {
            return RedirectToAction("Index");
        }

        _db.TblBlogs.Remove(item);
        await _db.SaveChangesAsync();

        return RedirectToAction("Index");
    }
}