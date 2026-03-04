using EFCoreDemo.Shared;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDemo.StudentModule;

public class StudentService(CompanyContext context, AddressService addressService)
{
    private readonly AddressService _addressService = addressService;

    public async Task<Student> Create(Student student)
    {
        context.Students.Add(student);
        await context.SaveChangesAsync();

        return student;
    }

    public async Task<Student?> GetById(int id)
    {
        return await context.Students
            .Include(s => s.Address)
            .FirstOrDefaultAsync((s) => s.Id == id);
    }

    public async Task<List<Student>> GetAll()
    {
        return await context.Students.ToListAsync();
    }

    public async Task<Student?> Update(Student student)
    {
        var oldStudent = await context.Students.FirstOrDefaultAsync((s) => s.Id == student.Id);
        if (oldStudent is not null)
        {
            oldStudent.Name = student.Name != "" ? student.Name : oldStudent.Name;
            oldStudent.Age = student.Age != 0 ? student.Age : oldStudent.Age;
            oldStudent.UpdatedAt = DateTime.UtcNow;

            await context.SaveChangesAsync();
            return oldStudent;
        }

        return null;
    }

    public async Task<Student?> Delete(int id)
    {
        var student = await context.Students.FirstOrDefaultAsync((s) => s.Id == id);
        if (student is null) return null;

        context.Students.Remove(student);
        await context.SaveChangesAsync();
        return student;
    }

    public async Task<List<Student>> GetByName(string name)
    {
        return await context.Students.Where(s => s.Name == name).ToListAsync();
    }

    public async Task<Student?> UpdateAddress(int studentId, Address address)
    {
        var student = await context.Students
            .Include(student => student.Address)
            .FirstOrDefaultAsync((s) => s.Id == studentId);

        if (student.Address is not null)
        {
            student.Address.AddreLine = address.AddreLine;
            student.Address.State = address.State;
            await _addressService.Update(student.Address);
            return student;
        }

        student.Address = address;
        await context.SaveChangesAsync();
        return student ?? null;

        return student ?? null;
    }
}