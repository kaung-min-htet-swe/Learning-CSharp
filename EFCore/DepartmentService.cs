using EFCore.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace EFCore;

public class DepartmentService(EfcoreContext ctx)
{
    private readonly EfcoreContext _ctx = ctx;

    public (Department?, bool) Create(Department department)
    {
        _ctx.Add(department);
        var result = _ctx.SaveChanges();
        return result == 0
            ? (null, false)
            : (department, true);
    }

    public Department? RetrieveById(int id, bool includeStudents = false)
    {
        if (includeStudents)
        {
            return _ctx.Departments
                .Include((d) => d.Students)
                .FirstOrDefault((d) => d.Id == id);
        }

        return _ctx.Departments.FirstOrDefault((d) => d.Id == id);
    }

    public (Department?, bool) Update(Department department)
    {
        var d = _ctx.Departments.FirstOrDefault((d) => d.Id == department.Id);
        if (d is null) return (null, false);

        var updatedDepartment = _ctx.Departments.Update(department);
        var result = _ctx.SaveChanges();
        return result == 0
            ? (null, false)
            : (updatedDepartment.Entity, true);
    }

    public bool Delete(int id)
    {
        var d = _ctx.Departments.FirstOrDefault((d) => d.Id == id);
        if (d is null) return false;

        _ctx.Departments.Remove(d);
        var result = _ctx.SaveChanges();
        return result != 0;
    }
}