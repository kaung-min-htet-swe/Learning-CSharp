using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThemeDatabase;

namespace ThemeMvcApp.Controllers;

public class StudentController(AppDbContext ctx) : Controller
{
    private readonly AppDbContext _db = ctx;

    public async Task<IActionResult> Index()
    {
        var students = await _db.TblStudents
            .AsNoTracking()
            .Where(s => !s.DeleteFlag)
            .ToListAsync<TblStudent>();

        return View(students);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        [Bind("StudentNo,StudentName,FatherName,DateOfBirth,Gender,Address,MobileNo")]
        TblStudent student
    )
    {
        if (ModelState.IsValid)
        {
            student.DeleteFlag = false;
            _db.Add(student);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(student);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();
        var student = await _db.TblStudents.FirstOrDefaultAsync(s => s.StudentId == id && !s.DeleteFlag);
        if (student == null) return NotFound();

        return View(student);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(
        int? id,
        [Bind("StudentNo,StudentName,FatherName,DateOfBirth,Gender,Address,MobileNo")]
        TblStudent student)
    {
        if (id != student.StudentId) return NotFound();
        if (ModelState.IsValid)
        {
            _db.TblStudents.Update(student);
            var res = await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(student);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();
        var student = await _db.TblStudents.FirstOrDefaultAsync(s => s.StudentId == id && !s.DeleteFlag);
        if (student == null) return NotFound();

        return View(student);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var tblStudent = await _db.TblStudents.FindAsync(id);
        if (tblStudent != null)
        {
            tblStudent.DeleteFlag = true;
            _db.Update(tblStudent);
            await _db.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }
}