using EFCore.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace EFCore;

public class StudentService(EfcoreContext ctx)
{
    private readonly EfcoreContext _ctx = ctx;

    public Student? Create(Student student, int departmentId)
    {
        student.DepartmentId = departmentId;
        _ctx.Students.Add(student);
        var result = _ctx.SaveChanges();
        return result == 0
            ? null
            : student;
    }

    public Student? RetrieveById(int id, bool includeDepartment = false)
    {
        if (includeDepartment)
            return _ctx.Students
                .Include((s) => s.Department)
                .FirstOrDefault((s) => s.Id == id);
        return _ctx.Students.FirstOrDefault((s) => s.Id == id);
    }

    public Student? Update(int id, Student student)
    {
        var s = _ctx.Students.FirstOrDefault((s) => s.Id == id);
        if (s is null) return null;
        var updatedStudent = _ctx.Students.Update(student);
        var result = _ctx.SaveChanges();
        return result == 0
            ? null
            : updatedStudent.Entity;
    }

    public bool Delete(int id)
    {
        var s = _ctx.Students.FirstOrDefault((s) => s.Id == id);
        if (s is null) return false;
        _ctx.Students.Remove(s);
        var result = _ctx.SaveChanges();
        return result != 0;
    }
}