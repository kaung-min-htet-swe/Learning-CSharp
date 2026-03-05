using EFCore.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace EFCore;

public class CourseService(EfcoreContext ctx)
{
    private readonly EfcoreContext _ctx = ctx;

    public Course? Create(Course course)
    {
        _ctx.Courses.Add(course);
        var result = _ctx.SaveChanges();
        return result == 0
            ? null
            : course;
    }

    public List<Course> RetrieveList()
    {
        return _ctx.Courses.ToList();
    }

    public Course? RetrieveById(int id, bool includeStudents = false)
    {
        return _ctx.Courses.FirstOrDefault(c => c.Id == id);
    }

    public Student? RetrieveByStudentId(int studentId)
    {
        return _ctx.Students
            .FirstOrDefault(s => s.Id == studentId);
    }

    public Course? Update(int id, Course course)
    {
        var c = _ctx.Courses.FirstOrDefault(c => c.Id == id);
        if (c is null) return null;
        var updatedCourse = _ctx.Courses.Update(course);
        var result = _ctx.SaveChanges();
        return result == 0
            ? null
            : updatedCourse.Entity;
    }

    public bool Delete(int id)
    {
        var c = _ctx.Courses.FirstOrDefault(c => c.Id == id);
        if (c is null) return false;

        _ctx.Courses.Remove(c);
        var result = _ctx.SaveChanges();
        return result != 0;
    }
}