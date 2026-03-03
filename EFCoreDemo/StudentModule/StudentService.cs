using Microsoft.EntityFrameworkCore;

namespace EFCoreDemo.StudentModule;

public class StudentService
{
    private readonly CompanyContext _context;

    public StudentService(CompanyContext context)
    {
        _context = context;
    }

    public async Task<Student> Create(Student student)
    {
        _context.Students.Add(student);
        await _context.SaveChangesAsync();

        return student;
    }

    public async Task<Student?> GetById(int id)
    {
        return await _context.Students.FirstOrDefaultAsync((s) => s.Id == id);
    }

    public async Task<List<Student>> GetAll()
    {
        return await _context.Students.ToListAsync();
    }

    public async Task<Student?> Update(Student student)
    {
        var oldStudent = await _context.Students.FirstOrDefaultAsync((s) => s.Id == student.Id);
        if (oldStudent is not null)
        {
            oldStudent.Name = student.Name != "" ? student.Name : oldStudent.Name;
            oldStudent.Age = student.Age != 0 ? student.Age : oldStudent.Age;
            oldStudent.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return oldStudent;
        }

        return null;
    }

    public async Task<Student?> Delete(int id)
    {
        var student = await _context.Students.FirstOrDefaultAsync((s) => s.Id == id);
        if (student is null) return null;
        
        _context.Students.Remove(student);
        await _context.SaveChangesAsync();
        return student;

    }
}