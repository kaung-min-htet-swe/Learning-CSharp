using EFCoreDemo.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.CompilerServices;

namespace EFCoreDemo.StudentModule;

public class StudentModule
{
    public static async Task Run(CompanyContext ctx)
    {
        try
        {
            var service = new StudentService(ctx);
            // var newStudent = new Student()
            // {
            //     Age = 20,
            //     Name = "Kaung Min Htet",
            // };
        
            // var createdStudent = await service.Create(newStudent);
            // Ulits.PrintStudent(createdStudent);
            //     
            // Ulits.PrintStudent((await service.GetById(1))!);
            //
            // var updatedStudent = await service.Update(new Student()
            // {
            //     Id = 1,
            //     Name = "Kaung Kaung",
            // });
            // if (updatedStudent != null) Ulits.PrintStudent(updatedStudent);
            //
            // var deletedStudent = await service.Delete(1);
            // if (deletedStudent != null) Ulits.PrintStudent(deletedStudent);
            
            var students = await service.GetAll();
            foreach (var s in students)
            {
                Console.WriteLine("Student list");
                Ulits.PrintStudent(s);
            }

            var kaungminhtet = await service.GetByName("Kaung Min Htet");
            foreach (var s in kaungminhtet)
            {
                Console.WriteLine("Student list");
                Ulits.PrintStudent(s);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}